using AutoMapper;
using EdufyAPI.DTOs.StudentDTOs;
using EdufyAPI.Models.Roles;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        UserManager<AppUser> userManager) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly UserManager<AppUser> _userManager = userManager;


        // TODO: Implement the following methods.
        // 2. Delete a student by their unique identifier, edit it inside the IdenrifierController.
        // It should also allow the student to update his data.
        // - It Should Contain the following properties:
        // -Change Password, Change Email, Change Phone Number. If needed.

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

            var student = await _userManager.FindByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            var studentDTO = _mapper.Map<GetStudentsDTO>(student);

            return Ok(studentDTO);

        }

        // Other methods will be implemented inside: IdentityController.cs, CoursesController.cs, and StudentController.cs

    }
}
