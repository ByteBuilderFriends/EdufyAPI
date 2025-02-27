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

        public CourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        private readonly string ThumbnailsFolderName = "course-thumbnails";
        private readonly string VideosFolderName = "course-videos";
        // ✅ GET: api/Course
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseReadDTO>>> GetCourses()
        {
            var courses = await _unitOfWork.CourseRepository.GetAllAsync();

            if (!courses.Any())
            {
                return Ok(Enumerable.Empty<CourseReadDTO>());
            }

            var courseDtos = _mapper.Map<IEnumerable<CourseReadDTO>>(courses);

            // Add image URLs to each course DTO
            foreach (var courseDto in courseDtos)
            {
                //constructs the full URL for the course image, allowing the frontend to display it easily
                //Request.Scheme = hhtp/https - Request.Host = localhost:5000 or example.com - Path.GetFileName(course.ThumbnailUrl) = Example: image1.jpg
                //For example: https://localhost:5000/course-thumbnails/image1.jpg
                courseDto.ThumbnailUrl = ConstructFileUrlHelper.ConstructFileUrl(Request, ThumbnailsFolderName, courseDto.ThumbnailUrl);
            }
            return Ok(courseDtos);
        }

        // ✅ GET: api/Course/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseReadDTO>> GetCourseById(string id)
        {
            var course = await _unitOfWork.CourseRepository.GetByIdAsync(id);

            if (course == null)
            {
                return NotFound("Course not found.");
            }

            var courseDto = _mapper.Map<CourseReadDTO>(course);

            //constructs the full URL for the course image, allowing the frontend to display it easily
            //Request.Scheme = hhtp/https - Request.Host = localhost:5000 or example.com - Path.GetFileName(course.ThumbnailUrl) = Example: image1.jpg
            //For example: https://localhost:5000/course-thumbnails/image1.jpg
            var imageUrl = ConstructFileUrlHelper.ConstructFileUrl(Request, ThumbnailsFolderName, courseDto.ThumbnailUrl);
            courseDto.ThumbnailUrl = imageUrl;

            return Ok(courseDto);
        }

        // ✅ POST: api/Course
        [HttpPost]
        public async Task<ActionResult<CourseReadDTO>> CreateCourse([FromForm] CourseCreateDTO courseCreateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Save the thumbnail image and get the URL
            var imageUrl = await FileUploadHelper.UploadFileAsync(courseCreateDto.Thumbnail, "course-thumbnails");

            var course = _mapper.Map<Course>(courseCreateDto);
            course.ThumbnailUrl = imageUrl; //Since ThumbnailUrl is generated after saving the image, you still need to assign it manually.


            await _unitOfWork.CourseRepository.AddAsync(course);
            await _unitOfWork.SaveChangesAsync();

            var courseReadDto = _mapper.Map<CourseReadDTO>(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, courseReadDto);
        }

        // ✅ PUT: api/Course/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(string id, [FromForm] CourseUpdateDTO courseUpdateDto)
        {
            var course = await _unitOfWork.CourseRepository.GetByIdAsync(id);

            if (course == null)
            {
                return NotFound("Course not found.");
            }

            _mapper.Map(courseUpdateDto, course);

            if (courseUpdateDto.Thumbnail != null)
            {
                FileUploadHelper.DeleteFile(course.ThumbnailUrl);  // Delete the old image if exists
                var imageUrl = await FileUploadHelper.UploadFileAsync(courseUpdateDto.Thumbnail, "course-thumbnails");
                course.ThumbnailUrl = imageUrl;
            }

            await _unitOfWork.CourseRepository.UpdateAsync(course);
            await _unitOfWork.SaveChangesAsync();

            return Ok(_mapper.Map<CourseReadDTO>(course));
        }

        // ✅ DELETE: api/Course/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(string id)
        {
            var course = await _unitOfWork.CourseRepository.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound("Course not found.");
            }

            // Delete the image from the server
            FileUploadHelper.DeleteFile(course.ThumbnailUrl);

            // Remove the course from the database
            await _unitOfWork.CourseRepository.DeleteAsync(course);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
