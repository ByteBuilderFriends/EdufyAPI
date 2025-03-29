using AutoMapper;
using EdufyAPI.DTOs.StudentDTOs;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers.RoleControllers
{
    /// <summary>
    /// Controller for managing student-related operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(
        IUnitOfWork unitOfWork,
        IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Retrieves all students
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/Student
        ///     
        /// </remarks>
        /// <returns>List of all registered students</returns>
        /// <response code="200">Returns list of students</response>
        /// <response code="404">No students found</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSAllStudents()
        {
            var students = await _unitOfWork.StudentRepository.GetAllAsync();

            if (students == null || !students.Any())
                return NotFound("No content found");

            List<GetStudentsDTO> studentsDTO = _mapper.Map<List<GetStudentsDTO>>(students);
            return Ok(studentsDTO);
        }

        /// <summary>
        /// Retrieves a specific student by ID
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/Student/abc123
        ///     
        /// </remarks>
        /// <param name="id">Student ID</param>
        /// <returns>Student details</returns>
        /// <response code="200">Returns requested student</response>
        /// <response code="404">Student not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Retrieves all courses for a specific student
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/Student/GetAllCourses?StudentId=abc123
        ///     
        /// </remarks>
        /// <param name="StudentId">ID of the student to retrieve courses for</param>
        /// <returns>List of enrolled courses</returns>
        /// <response code="200">Returns list of student's courses</response>
        /// <response code="400">Missing StudentId parameter</response>
        /// <response code="404">Student not found</response>
        [HttpGet("GetAllCourses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllStudentCourses(string StudentId)
        {
            if (StudentId == null)
                return BadRequest();

            var student = await _unitOfWork.StudentRepository.GetByIdAsync(StudentId);
            if (student == null)
                return NotFound("Student not found.");

            var studentCourses = await _unitOfWork.EnrollmentRepository.GetByCondition(sc => sc.StudentId == StudentId);
            List<GetStudentCoursesDTO> studentCoursesDTO = _mapper.Map<List<GetStudentCoursesDTO>>(studentCourses);

            return Ok(studentCoursesDTO);
        }
    }
}