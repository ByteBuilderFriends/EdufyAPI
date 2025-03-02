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

        [HttpGet]
        public async Task<IActionResult> GetAllEnrollments()
        {
            var enrollments = await _unitOfWork.EnrollmentRepository.GetAllAsync();
            if (!enrollments.Any())
            {
                return Ok(Enumerable.Empty<EnrollmentReadDTO>());
            }
            //var enrollmentDtos = _mapper.Map<EnrollmentReadDTO>(enrollments);
            var enrollmentDtos = _mapper.Map<IEnumerable<EnrollmentReadDTO>>(enrollments);   //Since enrollments is a collection, you need to map it to a collection of DTOs (IEnumerable<EnrollmentReadDTO>) rather than a single DTO.
            return Ok(enrollmentDtos);
        }

        [HttpGet]
        public async Task<IActionResult> GetEnrollmentAsync(string studentId, string courseId)
        {
            var enrollment = await _unitOfWork.EnrollmentRepository.GetAsync(studentId, courseId);
            if (enrollment == null) return NotFound();
            var enrollmentDtos = _mapper.Map<EnrollmentReadDTO>(enrollment);
            return Ok(enrollmentDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Enroll(EnrollmentCreateDTO enrollmentDto)
        {
            if (await _unitOfWork.EnrollmentRepository.GetAsync(enrollmentDto.StudentId, enrollmentDto.CourseId) != null)
                return BadRequest("Already enrolled.");

            var Enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            await _unitOfWork.EnrollmentRepository.AddAsync(Enrollment);

            // Now add Course Progress for the student
            #region Add Course Progress
            var course = await _unitOfWork.CourseRepository.GetByIdAsync(enrollmentDto.CourseId);
            var student = await _unitOfWork.StudentRepository.GetByIdAsync(enrollmentDto.StudentId);

            var progress = new Progress
            {
                StudentId = student.Id,
                CourseId = course.Id,
                TotalLessonsCompleted = 0
            };

            await _unitOfWork.ProgressRepository.AddAsync(progress);
            #endregion


            return Ok("Enrollment successful.");
        }

        [HttpDelete]
        public async Task<IActionResult> UnEnroll(string studentId, string courseId)
        {
            var enrollment = await _unitOfWork.EnrollmentRepository.GetAsync(studentId, courseId);
            if (enrollment == null)
                return NotFound("Enrollment not found.");

            await _unitOfWork.EnrollmentRepository.DeleteAsync(enrollment);

            // Now delete the Course Progress for the student

            var progress = await _unitOfWork.ProgressRepository.GetAsync(studentId, courseId);
            if (progress == null)
                return Ok();

            await _unitOfWork.ProgressRepository.DeleteAsync(studentId, courseId);


            return Ok("Unenrollment successful.");
        }


        // 1. The student should be able to enroll in a course.
        // POST: api/StudentCourse/Enroll
        //[HttpPost("Enroll")]
        //public async Task<IActionResult> EnrollInCourse(string StudentId, string CourseId)
        //{
        //    if (StudentId == null || CourseId == null)
        //        return BadRequest();


        //    // Check if the student exists
        //    var student = await _unitOfWork.StudentRepository.GetByIdAsync(StudentId);
        //    if (student == null)
        //        return NotFound("Student not found.");

        //    // Check if the course exists
        //    var course = _unitOfWork.CourseRepository.GetByIdAsync(CourseId);
        //    if (course == null)
        //        return NotFound("Course not found.");

        // Check if the student is already enrolled in the course
        //var studentCourse = (StudentId, CourseId);
        //if (IsCourseEnrolled(StudentId, CourseId))
        //    return BadRequest("Student is already enrolled in the course.");

        // Enroll the student in the course
        //    var studentCourse = new StudentCourse
        //    {
        //        StudentId = StudentId,
        //        CourseId = CourseId
        //    };

        //    await _unitOfWork.StudentCourseRepository.AddAsync(studentCourse);

        //    return Ok();
        //}


        #region Helper Methods

        // Check If Course is Enrolled
        //private bool IsCourseEnrolled(string StudentId, string CourseId)
        //{
        //    var studentCourse = _unitOfWork.StudentCourseRepository.GetByCondition(sc => sc.StudentId == StudentId && sc.CourseId == CourseId);
        //    return studentCourse != null;
        //}

        #endregion

    }
}
