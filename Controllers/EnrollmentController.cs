using AutoMapper;
using EdufyAPI.DTOs;
using EdufyAPI.DTOs.EnrollmentDTOs;
using EdufyAPI.DTOs.StudentCourseDTOs;
using EdufyAPI.DTOs.StudentDTOs;
using EdufyAPI.Models;
using EdufyAPI.Repository.Interfaces;
using EdufyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICacheService _cache;
        private readonly ILogger<EnrollmentController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnrollmentController"/> class.
        /// </summary>
        /// <param name="unitOfWork">Unit of Work for database transactions.</param>
        /// <param name="mapper">AutoMapper instance.</param>
        /// <param name="cache">Cache service for caching data.</param>
        public EnrollmentController(IUnitOfWork unitOfWork, IMapper mapper, ICacheService cache, ILogger<EnrollmentController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all enrollments.
        /// </summary>
        /// <returns>A list of all enrollments.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllEnrollments()
        {
            var cacheKey = "allEnrollments";
            try
            {
                var enrollmentDtos = await _cache.GetDataAsync<IEnumerable<EnrollmentReadDTO>>(cacheKey);

                if (enrollmentDtos == null)
                {
                    var enrollments = await _unitOfWork.EnrollmentRepository.GetAllAsync();
                    if (!enrollments.Any())
                        return Ok(Enumerable.Empty<EnrollmentReadDTO>());

                    enrollmentDtos = _mapper.Map<IEnumerable<EnrollmentReadDTO>>(enrollments);
                    await _cache.SetDataAsync(cacheKey, enrollmentDtos, DateTimeOffset.Now.AddMinutes(10));
                }

                return Ok(enrollmentDtos);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all enrollments.");
                return StatusCode(500, $"An error occurred while retrieving enrollments. {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves an enrollment by student and course IDs.
        /// </summary>
        /// <param name="studentId">The ID of the student.</param>
        /// <param name="courseId">The ID of the course.</param>
        /// <returns>The enrollment details.</returns>
        [HttpGet]
        public async Task<IActionResult> GetEnrollmentAsync(string studentId, string courseId)
        {
            var cacheKey = $"enrollment-{studentId}-{courseId}";
            try
            {
                var enrollmentDto = await _cache.GetDataAsync<EnrollmentReadDTO>(cacheKey);

                if (enrollmentDto == null)
                {
                    var enrollment = await _unitOfWork.EnrollmentRepository.GetAsync(studentId, courseId);
                    if (enrollment == null)
                        return NotFound("Enrollment not found.");

                    enrollmentDto = _mapper.Map<EnrollmentReadDTO>(enrollment);
                    await _cache.SetDataAsync(cacheKey, enrollmentDto, DateTimeOffset.Now.AddMinutes(10));
                }

                return Ok(enrollmentDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving enrollment.");
                return StatusCode(500, $"An error occurred while retrieving the enrollment. {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves the courses a student is enrolled in.
        /// </summary>
        /// <param name="studentId">The student's ID.</param>
        /// <returns>A list of courses the student is enrolled in.</returns>
        [HttpGet]
        public async Task<IActionResult> GetEnrolledCoursesByStudent(string studentId)
        {
            var cacheKey = $"student-courses-{studentId}";
            try
            {
                var courseDtos = await _cache.GetDataAsync<IEnumerable<CourseReadDTO>>(cacheKey);

                if (courseDtos == null)
                {
                    var enrollments = await _unitOfWork.EnrollmentRepository.GetByCondition(e => e.StudentId == studentId);
                    if (!enrollments.Any())
                        return NotFound("No enrollments found for this student.");

                    courseDtos = _mapper.Map<IEnumerable<CourseReadDTO>>(enrollments.Select(e => e.Course));
                    await _cache.SetDataAsync(cacheKey, courseDtos, DateTimeOffset.Now.AddMinutes(10));
                }

                return Ok(courseDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving courses for student.");
                return StatusCode(500, $"An error occurred while retrieving courses for the student. {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves students enrolled in a specific course.
        /// </summary>
        /// <param name="courseId">The course ID.</param>
        /// <returns>A list of students enrolled in the course.</returns>
        [HttpGet]
        public async Task<IActionResult> GetStudentsEnrolledInCourse(string courseId)
        {
            var cacheKey = $"course-students-{courseId}";
            try
            {
                var studentDtos = await _cache.GetDataAsync<IEnumerable<StudentReadDTO>>(cacheKey);

                if (studentDtos == null)
                {
                    var enrollments = await _unitOfWork.EnrollmentRepository.GetByCondition(e => e.CourseId == courseId);
                    if (!enrollments.Any())
                        return NotFound("No students enrolled in this course.");

                    studentDtos = _mapper.Map<IEnumerable<StudentReadDTO>>(enrollments.Select(e => e.Student));
                    await _cache.SetDataAsync(cacheKey, studentDtos, DateTimeOffset.Now.AddMinutes(10));
                }

                return Ok(studentDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving students enrolled in course.");
                return StatusCode(500, $"An error occurred while retrieving students enrolled in the course. {ex.Message}");
            }
        }

        /// <summary>
        /// Enrolls a student in a course.
        /// </summary>
        /// <param name="enrollmentDto">Enrollment details.</param>
        /// <returns>Enrollment confirmation.</returns>
        [HttpPost]
        public async Task<IActionResult> Enroll(EnrollmentCreateDTO enrollmentDto)
        {
            await _cache.RemoveDataAsync("allEnrollments");
            await _cache.RemoveDataAsync($"student-courses-{enrollmentDto.StudentId}");
            await _cache.RemoveDataAsync($"course-students-{enrollmentDto.CourseId}");

            if (await _unitOfWork.EnrollmentRepository.GetAsync(enrollmentDto.StudentId, enrollmentDto.CourseId) != null)
                return BadRequest("Already enrolled.");

            var course = await _unitOfWork.CourseRepository.GetByIdAsync(enrollmentDto.CourseId);
            if (course == null)
                return NotFound("Course not found.");

            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
                await _unitOfWork.EnrollmentRepository.AddAsync(enrollment);

                // Add course progress for the student
                var progress = new Progress
                {
                    StudentId = enrollmentDto.StudentId,
                    CourseId = enrollmentDto.CourseId,
                    TotalLessonsCompleted = 0,
                    CompletedProgress = false
                };
                await _unitOfWork.ProgressRepository.AddAsync(progress);

                // Update the student count before committing
                course.NumberOfStudentsEnrolled = await _unitOfWork.EnrollmentRepository.CountAsync(e => e.CourseId == enrollmentDto.CourseId);
                await _unitOfWork.CourseRepository.UpdateAsync(course);

                await transaction.CommitAsync();
                return Ok("Enrollment successful.");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Unenrolls a student from a course.
        /// </summary>
        /// <param name="studentId">The student's ID.</param>
        /// <param name="courseId">The course ID.</param>
        /// <returns>Unenrollment confirmation.</returns>
        [HttpDelete]
        public async Task<IActionResult> UnEnroll(string studentId, string courseId)
        {
            await _cache.RemoveDataAsync("allEnrollments");
            await _cache.RemoveDataAsync($"student-courses-{studentId}");
            await _cache.RemoveDataAsync($"course-students-{courseId}");

            var enrollment = await _unitOfWork.EnrollmentRepository.GetAsync(studentId, courseId);
            if (enrollment == null)
                return NotFound("Enrollment not found.");

            await _unitOfWork.EnrollmentRepository.DeleteAsync(enrollment);

            // Remove course progress if it exists
            var progress = await _unitOfWork.ProgressRepository.GetAsync(studentId, courseId);
            if (progress != null)
                await _unitOfWork.ProgressRepository.DeleteAsync(studentId, courseId);

            return Ok("Unenrollment successful.");
        }
    }
}
