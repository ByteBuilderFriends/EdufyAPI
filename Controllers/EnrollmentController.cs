using AutoMapper;
using EdufyAPI.DTOs;
using EdufyAPI.DTOs.EnrollmentDTOs;
using EdufyAPI.DTOs.StudentCourseDTOs;
using EdufyAPI.DTOs.StudentDTOs;
using EdufyAPI.Models;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace EdufyAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public EnrollmentController(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        /// <summary>
        /// Retrieves all course enrollments.
        /// </summary>
        /// <returns>A list of enrollments.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllEnrollments()
        {
            var cacheKey = "allEnrollments";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<EnrollmentReadDTO> enrollmentDtos))
            {
                var enrollments = await _unitOfWork.EnrollmentRepository.GetAllAsync();
                if (!enrollments.Any())
                {
                    return Ok(Enumerable.Empty<EnrollmentReadDTO>());
                }

                enrollmentDtos = _mapper.Map<IEnumerable<EnrollmentReadDTO>>(enrollments);

                // Set cache options
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(10)) // Cache for 10 minutes
                    .SetAbsoluteExpiration(TimeSpan.FromHours(1)); // Cache expires after 1 hour

                _cache.Set(cacheKey, enrollmentDtos, cacheOptions);
            }

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
            var cacheKey = $"enrollment-{studentId}-{courseId}";
            if (!_cache.TryGetValue(cacheKey, out EnrollmentReadDTO enrollmentDto))
            {
                var enrollment = await _unitOfWork.EnrollmentRepository.GetAsync(studentId, courseId);
                if (enrollment == null) return NotFound("Enrollment not found.");

                enrollmentDto = _mapper.Map<EnrollmentReadDTO>(enrollment);

                // Set cache options
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(10));

                _cache.Set(cacheKey, enrollmentDto, cacheOptions);
            }

            return Ok(enrollmentDto);
        }

        // Get all courses enrolled by a student
        [HttpGet]
        public async Task<IActionResult> GetEnrolledCoursesByStudent(string studentId)
        {
            var cacheKey = $"student-courses-{studentId}";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<CourseReadDTO> courseDtos))
            {
                var enrollments = await _unitOfWork.EnrollmentRepository.GetByCondition(e => e.StudentId == studentId);
                if (!enrollments.Any())
                    return NotFound("No enrollments found for this student.");

                courseDtos = _mapper.Map<IEnumerable<CourseReadDTO>>(enrollments.Select(e => e.Course));

                // Set cache options
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(10));

                _cache.Set(cacheKey, courseDtos, cacheOptions);
            }

            return Ok(courseDtos);
        }

        // Get all students enrolled in a course
        [HttpGet]
        public async Task<IActionResult> GetStudentsEnrolledInCourse(string courseId)
        {
            var cacheKey = $"course-students-{courseId}";
            if (!_cache.TryGetValue(cacheKey, out IEnumerable<StudentReadDTO> studentDtos))
            {
                var enrollments = await _unitOfWork.EnrollmentRepository.GetByCondition(e => e.CourseId == courseId);
                if (!enrollments.Any())
                    return NotFound("No students enrolled in this course.");

                studentDtos = _mapper.Map<IEnumerable<StudentReadDTO>>(enrollments.Select(e => e.Student));

                // Set cache options
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(10));

                _cache.Set(cacheKey, studentDtos, cacheOptions);
            }

            return Ok(studentDtos);
        }

        /// <summary>
        /// Enrolls a student in a course.
        /// </summary>
        /// <param name="enrollmentDto">The enrollment details.</param>
        /// <returns>A success message if enrollment is successful.</returns>
        [HttpPost]
        public async Task<IActionResult> Enroll(EnrollmentCreateDTO enrollmentDto)
        {
            // Invalidate relevant caches after enrollment action
            _cache.Remove("allEnrollments");
            _cache.Remove($"student-courses-{enrollmentDto.StudentId}");
            _cache.Remove($"course-students-{enrollmentDto.CourseId}");

            if (await _unitOfWork.EnrollmentRepository.GetAsync(enrollmentDto.StudentId, enrollmentDto.CourseId) != null)
                return BadRequest("Already enrolled.");

            var course = await _unitOfWork.CourseRepository.GetByIdAsync(enrollmentDto.CourseId);
            if (course == null)
                return NotFound("Course not found.");

            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
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
            // Invalidate relevant caches after unenrollment action
            _cache.Remove("allEnrollments");
            _cache.Remove($"student-courses-{studentId}");
            _cache.Remove($"course-students-{courseId}");

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
