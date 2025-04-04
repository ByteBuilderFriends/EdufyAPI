using AutoMapper;
using EduConnectAPI.Models;
using EdufyAPI.DTOs.CertificateDTOs;
using EdufyAPI.Repository.Interfaces;
using EdufyAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CertificateController(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ICacheService cacheService,
        ILogger<CertificateController> logger) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly ICacheService _cacheService = cacheService;
        private readonly ILogger<CertificateController> _logger = logger;

        private static string GetCertificateCacheKey(string id) => $"certificate_{id}";
        private const string AllCertificatesCacheKey = "allCertificates";

        /// <summary>
        /// Generates a new certificate for a student who has completed a course.
        /// </summary>
        /// <param name="progressId">The ID of the progress record associated with the completed course.</param>
        /// <returns>Returns an HTTP 200 status on success, 400 if progressId is missing, and 404 if progress is not found.</returns>
        [HttpPost]
        public async Task<IActionResult> AutoGenerateCertificate(string progressId)
        {
            if (string.IsNullOrWhiteSpace(progressId))
            {
                return BadRequest("Progress Id is required");
            }

            try
            {
                var progress = await _unitOfWork.ProgressRepository.GetByIdAsync(progressId);
                if (progress == null)
                {
                    return NotFound("Progress record not found");
                }

                if (progress.IsCompleted)
                {
                    var certificate = new Certificate
                    {
                        CertificateNumber = Guid.NewGuid().ToString(),
                        IssueDate = DateTime.UtcNow,
                        ProgressId = progressId
                    };

                    await _unitOfWork.CertificateRepository.AddAsync(certificate);

                    // Invalidate the old cache
                    await _cacheService.RemoveDataAsync(AllCertificatesCacheKey);


                    var certificateDTO = _mapper.Map<GetCertificateDTO>(certificate);

                    // Cache the new certificate
                    await _cacheService.SetDataAsync(AllCertificatesCacheKey, certificateDTO, DateTimeOffset.Now.AddMinutes(10));

                    return Ok(new
                    {
                        message = "Certificate generated successfully.",
                        certificate = certificateDTO
                    });
                }

                return BadRequest("Progress is not yet completed, certificate cannot be generated.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating certificate for Progress ID: {ProgressId}", progressId);
                return StatusCode(500, $"Error generating certificate: {ex.Message}");
            }
        }


        /// <summary>
        /// Retrieves all certificates issued to students.
        /// </summary>
        /// <returns>Returns a list of certificates or a 204 status if no certificates exist.</returns>
        [HttpGet]
        public async Task<IActionResult> GetCertificates()
        {
            try
            {
                var certificatesDTO = await _cacheService.GetDataAsync<IEnumerable<GetCertificateDTO>>(AllCertificatesCacheKey);

                if (certificatesDTO == null)
                {
                    var certificates = await _unitOfWork.CertificateRepository.GetAllAsync();
                    if (certificates == null || !certificates.Any())
                    {
                        return NoContent();
                    }

                    certificatesDTO = _mapper.Map<IEnumerable<GetCertificateDTO>>(certificates);
                    await _cacheService.SetDataAsync(AllCertificatesCacheKey, certificatesDTO, DateTimeOffset.Now.AddMinutes(10));
                }

                return Ok(certificatesDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching certificates: {ex.Message}");
                return StatusCode(500, $"Error fetching certificates: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a certificate by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the certificate.</param>
        /// <returns>Returns the certificate if found, otherwise a 404 status.</returns>
        [HttpGet]
        public async Task<IActionResult> GetCertificateById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Certificate Id is required");
            }

            try
            {
                var certificateDTO = await _cacheService.GetDataAsync<GetCertificateDTO>(GetCertificateCacheKey(id));
                if (certificateDTO == null)
                {
                    var certificate = await _unitOfWork.CertificateRepository.GetByIdAsync(id);
                    if (certificate == null)
                    {
                        return NotFound();
                    }
                    certificateDTO = _mapper.Map<GetCertificateDTO>(certificate);
                    await _cacheService.SetDataAsync(GetCertificateCacheKey(id), certificateDTO, DateTimeOffset.Now.AddMinutes(10));
                }
                return Ok(certificateDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching certificate: {ex.Message}");
                return StatusCode(500, $"Error fetching certificate: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates the remarks of a certificate.
        /// </summary>
        /// <param name="id">The ID of the certificate.</param>
        /// <param name="remarks">The new remarks to update.</param>
        /// <returns>Returns an HTTP 200 status on success, 400 if ID is missing, or 404 if certificate is not found.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCertificateRemarks(string id, string remarks)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Certificate Id is required");
            }

            var certificate = await _unitOfWork.CertificateRepository.GetByIdAsync(id);
            if (certificate == null)
            {
                return NotFound();
            }

            try
            {
                // Remove the old cache entry
                await _cacheService.RemoveDataAsync(GetCertificateCacheKey(id));
                await _cacheService.RemoveDataAsync(AllCertificatesCacheKey);

                // Update the certificate remarks
                certificate.Remarks = remarks;
                await _unitOfWork.CertificateRepository.UpdateAsync(certificate);

                // Add the updated certificate to the cache
                var updatedCertificateDTO = _mapper.Map<GetCertificateDTO>(certificate);
                await _cacheService.SetDataAsync(GetCertificateCacheKey(id), updatedCertificateDTO, DateTimeOffset.Now.AddMinutes(10));

                return Ok(new
                {
                    message = "Certificate remarks updated successfully.",
                    certificate = updatedCertificateDTO
                });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating certificate remarks for Certificate ID: {id}", id);
                return StatusCode(500, $"Error updating certificate remarks: {ex.Message}");
            }
        }
    }
}
