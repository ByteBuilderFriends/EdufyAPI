using AutoMapper;
using EdufyAPI.DTOs.StudentDTOs;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(
        IUnitOfWork unitOfWork,
        IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;


        // 3. The student should be able to enroll in a course.Inside CoursesController.

        // Get all students.
        [HttpGet]
        public async Task<IActionResult> GetSAllStudents()
        {
            var students = await _unitOfWork.StudentRepository.GetAllAsync();

            if (students == null || !students.Any())
                return NotFound("No content found");

            List<GetStudentsDTO> studentsDTO = _mapper.Map<List<GetStudentsDTO>>(students);


            return Ok(studentsDTO);
        }

        // Get a student by their unique identifier.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(string id)
        {

            var student = await _unitOfWork.StudentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            var studentDTO = _mapper.Map<GetStudentsDTO>(student);

            return Ok(studentDTO);

        }

        [HttpGet("GetAllCourses")]
        public async Task<IActionResult> GetAllStudentCourses(string StudentId)
        {
            if (StudentId == null)
                return BadRequest();
            // Check if the student exists
            var student = await _unitOfWork.StudentRepository.GetByIdAsync(StudentId);
            if (student == null)
                return NotFound("Student not found.");
            // Get all courses the student is enrolled in
            var studentCourses = await _unitOfWork.StudentCourseRepository.GetByCondition(sc => sc.StudentId == StudentId);

            List<GetStudentCoursesDTO> studentCoursesDTO = _mapper.Map<List<GetStudentCoursesDTO>>(studentCourses);
            return Ok(studentCoursesDTO);
        }

    }
}
