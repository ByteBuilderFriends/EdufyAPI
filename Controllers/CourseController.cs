using AutoMapper;
using EdufyAPI.DTOs;
using EdufyAPI.DTOs.CourseDTOs;
using EdufyAPI.Models;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // ✅ GET: api/Course
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseReadDTO>>> GetCourses()
        {
            var courses = await _unitOfWork.CourseRepository.GetAllAsync();
            var courseDtos = _mapper.Map<IEnumerable<CourseReadDTO>>(courses);
            return Ok(courseDtos);
        }

        // ✅ GET: api/Course/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseReadDTO>> GetCourseById(int id)
        {
            var course = await _unitOfWork.CourseRepository.GetByIdAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            var courseDto = _mapper.Map<CourseReadDTO>(course);
            return Ok(courseDto);
        }

        // ✅ POST: api/Course
        [HttpPost]
        public async Task<ActionResult<CourseReadDTO>> CreateCourse(CourseCreateDTO courseCreateDto)
        {
            var course = _mapper.Map<Course>(courseCreateDto);
            await _unitOfWork.CourseRepository.AddAsync(course);
            await _unitOfWork.SaveChangesAsync();

            var courseReadDto = _mapper.Map<CourseReadDTO>(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, courseReadDto);
        }

        // ✅ PUT: api/Course/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, CourseUpdateDTO courseUpdateDto)
        {
            var existingCourse = await _unitOfWork.CourseRepository.GetByIdAsync(id);

            if (existingCourse == null)
            {
                return NotFound();
            }

            _mapper.Map(courseUpdateDto, existingCourse);
            await _unitOfWork.CourseRepository.UpdateAsync(existingCourse);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        // ✅ DELETE: api/Course/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _unitOfWork.CourseRepository.DeleteAsync(id);

            if (!result)
            {
                return NotFound();
            }

            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
