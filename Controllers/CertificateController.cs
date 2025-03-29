using AutoMapper;
using EduConnectAPI.Models;
using EdufyAPI.DTOs.CertificateDTOs;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CertificateController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

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
            }

            return Ok("Certificate generated successfully");
        }

        /// <summary>
        /// Retrieves all certificates issued to students.
        /// </summary>
        /// <returns>Returns a list of certificates or a 204 status if no certificates exist.</returns>
        [HttpGet]
        public async Task<IActionResult> GetCertificates()
        {
            var certificates = await _unitOfWork.CertificateRepository.GetAllAsync();
            if (certificates == null || !certificates.Any())
            {
                return NoContent();
            }

            var certificatesDTO = _mapper.Map<List<GetCertificateDTO>>(certificates);
            return Ok(certificatesDTO);
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

            var certificate = await _unitOfWork.CertificateRepository.GetByIdAsync(id);
            if (certificate == null)
            {
                return NotFound();
            }

            var certificateDTO = _mapper.Map<GetCertificateDTO>(certificate);
            return Ok(certificateDTO);
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

            certificate.Remarks = remarks;
            await _unitOfWork.CertificateRepository.UpdateAsync(certificate);
            return Ok("Certificate remarks updated successfully");
        }
    }
}
