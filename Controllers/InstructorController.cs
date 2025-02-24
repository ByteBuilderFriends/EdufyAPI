using AutoMapper;
using EdufyAPI.DTOs.InstructorDTOs;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class InstructorController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;


        // GET: api/Instructor

        [HttpGet]
        public async Task<IActionResult> GetAllInstructors()
        {
            var instructors = await _unitOfWork.InstructorRepository.GetAllAsync();

            if (instructors == null)
                return NoContent();

            var instructorDtos = _mapper.Map<IEnumerable<InstructorReadDTO>>(instructors);

            return Ok(instructorDtos);
        }

        // GET: api/Instructor/5

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstructorById(string id)
        {
            var instructor = await _unitOfWork.InstructorRepository.GetByIdAsync(id);
            if (instructor == null)
                return NotFound();
            var instructorDto = _mapper.Map<InstructorReadDTO>(instructor);
            return Ok(instructorDto);
        }

        // POST: api/Course/5/Instructor

        [HttpPost("{id}/Instructor")]
        public async Task<IActionResult> GetInstructorByCourseId(string id)
        {
            var course = await _unitOfWork.CourseRepository.GetByIdAsync(id);
            if (course == null)
                return NotFound();

            var instructor = await _unitOfWork.InstructorRepository.GetByIdAsync(course.InstructorId);
            if (instructor == null)
                return NotFound();

            var instructorDto = _mapper.Map<InstructorReadDTO>(instructor);
            return Ok(instructorDto);
        }

        // Upload Course
        //public async Task<IActionResult> UploadCourse(Course course)
        //{
        //    return Ok();
        //}


    }
}
