using AutoMapper;
using EdufyAPI.DTOs.EnrollmentDTOs;
using EdufyAPI.DTOs.StudentCourseDTOs;
using EdufyAPI.Models;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EnrollmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all course enrollments.
        /// </summary>
        /// <returns>A list of enrollments.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllEnrollments()
        {
            var enrollments = await _unitOfWork.EnrollmentRepository.GetAllAsync();
            if (!enrollments.Any())
            {
                return Ok(Enumerable.Empty<EnrollmentReadDTO>());
            }

            var enrollmentDtos = _mapper.Map<IEnumerable<EnrollmentReadDTO>>(enrollments);
            return Ok(enrollmentDtos);
        }

        /// <summary>
        /// Retrieves a specific enrollment based on student ID and course ID.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <param name="courseId">The ID of the course.</param>
        /// <returns>The enrollment details.</returns>
        [HttpGet]
        public async Task<IActionResult> GetEnrollmentAsync(string studentId, string courseId)
        {
            var enrollment = await _unitOfWork.EnrollmentRepository.GetAsync(studentId, courseId);
            if (enrollment == null) return NotFound("Enrollment not found.");

            var enrollmentDtos = _mapper.Map<EnrollmentReadDTO>(enrollment);
            return Ok(enrollmentDtos);
        }

        /// <summary>
        /// Enrolls a student in a course.
        /// </summary>
        /// <param name="enrollmentDto">The enrollment details.</param>
        /// <returns>A success message if enrollment is successful.</returns>
        [HttpPost]
        public async Task<IActionResult> Enroll(EnrollmentCreateDTO enrollmentDto)
        {
            if (await _unitOfWork.EnrollmentRepository.GetAsync(enrollmentDto.StudentId, enrollmentDto.CourseId) != null)
                return BadRequest("Already enrolled.");

            var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            await _unitOfWork.EnrollmentRepository.AddAsync(enrollment);

            // Add course progress for the student
            var progress = new Progress
            {
                StudentId = enrollmentDto.StudentId,
                CourseId = enrollmentDto.CourseId,
                TotalLessonsCompleted = 0
            };
            await _unitOfWork.ProgressRepository.AddAsync(progress);

            return Ok("Enrollment successful.");
        }

        /// <summary>
        /// Unenrolls a student from a course.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <param name="courseId">The ID of the course.</param>
        /// <returns>A success message if unenrollment is successful.</returns>
        [HttpDelete]
        public async Task<IActionResult> UnEnroll(string studentId, string courseId)
        {
            var enrollment = await _unitOfWork.EnrollmentRepository.GetAsync(studentId, courseId);
            if (enrollment == null)
                return NotFound("Enrollment not found.");

            await _unitOfWork.EnrollmentRepository.DeleteAsync(enrollment);

            // Remove course progress if it exists
            var progress = await _unitOfWork.ProgressRepository.GetAsync(studentId, courseId);
            if (progress != null)
            {
                await _unitOfWork.ProgressRepository.DeleteAsync(studentId, courseId);
            }

            return Ok("Unenrollment successful.");
        }
    }
}
