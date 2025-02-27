using EdufyAPI.Models;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentCourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // 1. The student should be able to enroll in a course.
        // POST: api/StudentCourse/Enroll
        [HttpPost("Enroll")]
        public async Task<IActionResult> EnrollInCourse(string StudentId, string CourseId)
        {
            if (StudentId == null || CourseId == null)
                return BadRequest();


            // Check if the student exists
            var student = await _unitOfWork.StudentRepository.GetByIdAsync(StudentId);
            if (student == null)
                return NotFound("Student not found.");

            // Check if the course exists
            var course = _unitOfWork.CourseRepository.GetByIdAsync(CourseId);
            if (course == null)
                return NotFound("Course not found.");

            // Check if the student is already enrolled in the course
            //var studentCourse = (StudentId, CourseId);
            //if (IsCourseEnrolled(StudentId, CourseId))
            //    return BadRequest("Student is already enrolled in the course.");

            // Enroll the student in the course
            var studentCourse = new StudentCourse
            {
                StudentId = StudentId,
                CourseId = CourseId
            };

            await _unitOfWork.StudentCourseRepository.AddAsync(studentCourse);

            return Ok();
        }


        #region Helper Methods

        // Check If Course is Enrolled
        private bool IsCourseEnrolled(string StudentId, string CourseId)
        {
            var studentCourse = _unitOfWork.StudentCourseRepository.GetByCondition(sc => sc.StudentId == StudentId && sc.CourseId == CourseId);
            return studentCourse != null;
        }

        #endregion

    }
}
