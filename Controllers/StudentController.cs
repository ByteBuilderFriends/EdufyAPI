using AutoMapper;
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

        // Get all students.
        [HttpGet]
        public async Task<IActionResult> GetSAllStudents()
        {
            var students = await _userManager.GetUsersInRoleAsync("Student");

            if (students == null || !students.Any())
            {
                return NotFound("No content found");
            }

            return Ok(students);
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
            return Ok(student);

        }

        // Create a new student.
        // NOTE: I don't know if i need to Create Student here, as we have the register method in IdentityController
        // So am thinking to edit it to just add the student role to the user

        //[HttpPost]
        //public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDTO createStudentDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var student = _mapper.Map<Student>(createStudentDTO);
        //    // Complete the logic to create a student here

        //    var result = await _userManager.CreateAsync(student, createStudentDTO.Password);
        //    if (result.Succeeded)
        //    {
        //        var studentRole = await _userManager.AddToRoleAsync(student, "Student");
        //        if (!studentRole.Succeeded)
        //        {
        //            return BadRequest(studentRole.Errors);
        //        }

        //        else
        //        {
        //            return BadRequest(result.Errors);
        //        }
        //    }
        //    return Ok();
        //}

    }
}
