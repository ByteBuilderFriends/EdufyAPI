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

        // Create a new certificate for a student who has completed a course.

        // !NOTE: I need to check if it's better to use Progress Object or ProgressId
        [HttpPost]
        public async Task<IActionResult> AutoGenerateCertificate(int progressId)
        {
            if (progressId == 0)
            {
                return BadRequest("Progress Id is required");
            }

            var progress = await _unitOfWork.ProgressRepository.GetByIdAsync(progressId);
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

            return Ok();
        }

        // Get all certificates issued to students.
        [HttpGet]
        public async Task<IActionResult> GetCertificates()
        {
            var certificates = await _unitOfWork.CertificateRepository.GetAllAsync();
            if (certificates == null)
            {
                return NoContent();
            }

            var certificatesDTO = _mapper.Map<List<GetCertificateDTO>>(certificates);
            return Ok(certificatesDTO);
        }

        // Get a certificate by its unique identifier.
        [HttpGet]
        public async Task<IActionResult> GetCertificateById(int id)
        {
            if (id == 0)
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

        // Get all certificates issued to a student.
        //[HttpGet]
        //public async Task<IActionResult> GetStudentCertificates(int studentId)
        //{
        //    if (studentId == 0)
        //    {
        //        return BadRequest("Student Id is required");
        //    }
        //    var certificates = await _unitOfWork.CertificateRepository.GetCertificatesByStudentId(studentId);
        //    if (certificates == null)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(certificates);
        //}

        // Update a certificate's remarks.
        [HttpPut]
        public async Task<IActionResult> UpdateCertificateRemarks(int id, string remarks)
        {
            if (id == 0)
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
            return Ok();
        }
    }
}


/*
NOTE:
We need to Add in the student Controller the following methods:
- GetStudentCertificates
 */

