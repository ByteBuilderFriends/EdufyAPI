using AutoMapper;
using EdufyAPI.DTOs;
using EdufyAPI.DTOs.CourseDTOs;
using EdufyAPI.Helpers;
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
        private readonly string ThumbnailsFolderName = "course-thumbnails";

        public CourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all courses available in the system.
        /// </summary>
        /// <returns>A list of courses with their details.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseReadDTO>>> GetCourses()
        {
            var courses = await _unitOfWork.CourseRepository.GetAllAsync();
            if (!courses.Any())
                return Ok(Enumerable.Empty<CourseReadDTO>());

            var courseDtos = _mapper.Map<IEnumerable<CourseReadDTO>>(courses);
            foreach (var courseDto in courseDtos)
            {
                courseDto.ThumbnailUrl = ConstructFileUrlHelper.ConstructFileUrl(Request, ThumbnailsFolderName, courseDto.ThumbnailUrl);
            }
            return Ok(courseDtos);
        }

        /// <summary>
        /// Retrieves a specific course by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the course.</param>
        /// <returns>The course details if found; otherwise, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseReadDTO>> GetCourseById(string id)
        {
            var course = await _unitOfWork.CourseRepository.GetByIdAsync(id);
            if (course == null)
                return NotFound("Course not found.");

            var courseDto = _mapper.Map<CourseReadDTO>(course);
            courseDto.ThumbnailUrl = ConstructFileUrlHelper.ConstructFileUrl(Request, ThumbnailsFolderName, courseDto.ThumbnailUrl);
            return Ok(courseDto);
        }

        /// <summary>
        /// Retrieves all courses taught by a specific instructor.
        /// </summary>
        /// <param name="instructorId">The unique identifier of the instructor.</param>
        /// <returns>A list of courses assigned to the instructor.</returns>
        [HttpGet("{instructorId}")]
        public async Task<ActionResult<IEnumerable<CourseReadDTO>>> GetInstructorCourses(string instructorId)
        {
            var courses = await _unitOfWork.CourseRepository.GetByCondition(c => c.InstructorId == instructorId);
            if (!courses.Any())
                return Ok(Enumerable.Empty<CourseReadDTO>());

            var courseDtos = _mapper.Map<IEnumerable<CourseReadDTO>>(courses);
            foreach (var courseDto in courseDtos)
            {
                courseDto.ThumbnailUrl = ConstructFileUrlHelper.ConstructFileUrl(Request, ThumbnailsFolderName, courseDto.ThumbnailUrl);
            }
            return Ok(courseDtos);
        }

        /// <summary>
        /// Creates a new course with the given details.
        /// </summary>
        /// <param name="courseCreateDto">The course creation request object.</param>
        /// <returns>The created course details.</returns>
        [HttpPost]
        public async Task<ActionResult<CourseReadDTO>> CreateCourse([FromForm] CourseCreateDTO courseCreateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var imageUrl = await FileUploadHelper.UploadFileAsync(courseCreateDto.Thumbnail, "course-thumbnails");
            var course = _mapper.Map<Course>(courseCreateDto);
            course.ThumbnailUrl = imageUrl;
            await _unitOfWork.CourseRepository.AddAsync(course);
            await _unitOfWork.SaveChangesAsync();
            var courseReadDto = _mapper.Map<CourseReadDTO>(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, courseReadDto);
        }

        /// <summary>
        /// Updates an existing course's details.
        /// </summary>
        /// <param name="id">The unique identifier of the course to update.</param>
        /// <param name="courseUpdateDto">The updated course data.</param>
        /// <returns>The updated course details.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(string id, [FromForm] CourseUpdateDTO courseUpdateDto)
        {
            var course = await _unitOfWork.CourseRepository.GetByIdAsync(id);
            if (course == null) return NotFound("Course not found.");
            _mapper.Map(courseUpdateDto, course);
            if (courseUpdateDto.Thumbnail != null)
            {
                FileUploadHelper.DeleteFile(course.ThumbnailUrl);
                var imageUrl = await FileUploadHelper.UploadFileAsync(courseUpdateDto.Thumbnail, "course-thumbnails");
                course.ThumbnailUrl = imageUrl;
            }
            await _unitOfWork.CourseRepository.UpdateAsync(course);
            await _unitOfWork.SaveChangesAsync();
            return Ok(_mapper.Map<CourseReadDTO>(course));
        }

        /// <summary>
        /// Deletes a course by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the course.</param>
        /// <returns>No content if deletion is successful.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(string id)
        {
            var course = await _unitOfWork.CourseRepository.GetByIdAsync(id);
            if (course == null) return NotFound("Course not found.");
            FileUploadHelper.DeleteFile(course.ThumbnailUrl);
            await _unitOfWork.CourseRepository.DeleteAsync(course);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
