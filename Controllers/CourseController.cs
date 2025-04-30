using AskAMuslimAPI.DTOs.CourseDTOs;
using AskAMuslimAPI.Enums;
using AutoMapper;
using EdufyAPI.DTOs;
using EdufyAPI.DTOs.CourseDTOs;
using EdufyAPI.Helpers;
using EdufyAPI.Models;
using EdufyAPI.Repository.Interfaces;
using EdufyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICacheService _memoryCache;
        private readonly ILogger<CourseController> _logger;
        private readonly string ThumbnailsFolderName = "course-thumbnails";

        public CourseController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICacheService memoryCache,
            ILogger<CourseController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves all courses available in the system.
        /// </summary>
        /// <returns>A list of courses with their details.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseReadDTO>>> GetCourses()
        {
            const string cacheKey = "all_courses";  // Cache key for all courses.

            try
            {
                var courseDtos = await _memoryCache.GetDataAsync<IEnumerable<CourseReadDTO>>(cacheKey);

                if (courseDtos == null)
                {
                    // Cache is empty, so retrieve from database.
                    var courses = await _unitOfWork.CourseRepository.GetAllAsync();
                    if (!courses.Any())
                        return Ok(Enumerable.Empty<CourseReadDTO>());

                    courseDtos = _mapper.Map<IEnumerable<CourseReadDTO>>(courses);
                    foreach (var courseDto in courseDtos)
                    {
                        courseDto.ThumbnailUrl = ConstructFileUrlHelper.ConstructFileUrl(Request, ThumbnailsFolderName, courseDto.ThumbnailUrl);
                    }

                    // Cache it with a 5-minute expiration time, handled by the service method.
                    await _memoryCache.SetDataAsync(cacheKey, courseDtos, DateTimeOffset.Now.AddMinutes(5));  // 5-minute expiration time.
                }

                return Ok(courseDtos);
            }
            catch (Exception ex)
            {
                // Log the exception (you can use ILogger here if needed)
                _logger.LogError($"An error occurred while fetching courses: {ex.Message}", ex);

                // Return a generic error response
                return StatusCode(500, "An error occurred while fetching courses.");
            }
        }


        /// <summary>
        /// Retrieves a specific course by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the course.</param>
        /// <returns>The course details if found; otherwise, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseReadByIdDTO>> GetCourseById(string id)
        {
            const string cacheKeyPrefix = "course_";  // Cache prefix for individual course.
            var cacheKey = $"{cacheKeyPrefix}{id}";

            try
            {
                var courseDto = await _memoryCache.GetDataAsync<CourseReadByIdDTO>(cacheKey);

                if (courseDto == null)
                {
                    // Cache is empty, so retrieve from database.
                    var course = await _unitOfWork.CourseRepository.GetByIdAsync(id);
                    if (course == null)
                        return NotFound("Course not found.");

                    courseDto = _mapper.Map<CourseReadByIdDTO>(course);
                    courseDto.ThumbnailUrl = ConstructFileUrlHelper.ConstructFileUrl(Request, ThumbnailsFolderName, courseDto.ThumbnailUrl);

                    await _memoryCache.SetDataAsync(cacheKey, courseDto, DateTimeOffset.Now.AddMinutes(5));
                }

                return Ok(courseDto);
            }

            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching course by ID: {ex.Message}", ex);
                return StatusCode(500, "An error occurred while fetching data");
            }

        }

        [HttpGet("ByName/{categoryName}")]
        public async Task<ActionResult<IEnumerable<CourseReadByIdDTO>>> GetCourseByCategoryName(string categoryName)
        {
            const string cacheKeyPrefix = "course_category_name_";
            var cacheKey = $"{cacheKeyPrefix}{categoryName.ToLower()}";

            try
            {
                var courseDtos = await _memoryCache.GetDataAsync<IEnumerable<CourseReadByIdDTO>>(cacheKey);
                if (courseDtos == null)
                {
                    if (!Enum.TryParse(typeof(CourseCategory), categoryName, true, out var categoryEnum))
                        return BadRequest("Invalid course category name.");

                    var category = (CourseCategory)categoryEnum;

                    var courses = await _unitOfWork.CourseRepository
                        .GetByCondition(c => c.Category == category);

                    if (!courses.Any())
                        return Ok(Enumerable.Empty<CourseReadByIdDTO>());

                    courseDtos = _mapper.Map<IEnumerable<CourseReadByIdDTO>>(courses);

                    foreach (var courseDto in courseDtos)
                    {
                        courseDto.ThumbnailUrl = ConstructFileUrlHelper
                            .ConstructFileUrl(Request, ThumbnailsFolderName, courseDto.ThumbnailUrl);
                    }

                    await _memoryCache.SetDataAsync(cacheKey, courseDtos, DateTimeOffset.Now.AddMinutes(5));
                }

                return Ok(courseDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching courses by category name: {ex.Message}", ex);
                return StatusCode(500, "An error occurred while fetching data.");
            }
        }


        // Get Courses by its Level
        [HttpGet("ByLevelName/{levelName}")]
        public async Task<ActionResult<IEnumerable<CourseReadByIdDTO>>> GetCourseByLevelName(string levelName)
        {
            const string cacheKeyPrefix = "course_level_name_";
            var cacheKey = $"{cacheKeyPrefix}{levelName.ToLower()}";

            try
            {
                var courseDtos = await _memoryCache.GetDataAsync<IEnumerable<CourseReadByIdDTO>>(cacheKey);
                if (courseDtos == null)
                {
                    if (!Enum.TryParse(typeof(CourseLevel), levelName, true, out var levelEnum))
                        return BadRequest("Invalid course level name.");

                    var level = (CourseLevel)levelEnum;

                    var courses = await _unitOfWork.CourseRepository
                        .GetByCondition(c => c.Level == level);

                    if (!courses.Any())
                        return Ok(Enumerable.Empty<CourseReadByIdDTO>());

                    courseDtos = _mapper.Map<IEnumerable<CourseReadByIdDTO>>(courses);

                    foreach (var courseDto in courseDtos)
                    {
                        courseDto.ThumbnailUrl = ConstructFileUrlHelper
                            .ConstructFileUrl(Request, ThumbnailsFolderName, courseDto.ThumbnailUrl);
                    }

                    await _memoryCache.SetDataAsync(cacheKey, courseDtos, DateTimeOffset.Now.AddMinutes(5));
                }

                return Ok(courseDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching courses by level name: {ex.Message}", ex);
                return StatusCode(500, "An error occurred while fetching data.");
            }
        }


        /// <summary>
        /// Retrieves all courses taught by a specific instructor.
        /// </summary>
        /// <param name="instructorId">The unique identifier of the instructor.</param>
        /// <returns>A list of courses assigned to the instructor.</returns>
        [HttpGet("{instructorId}")]
        public async Task<ActionResult<IEnumerable<CourseReadByIdDTO>>> GetInstructorCourses(string instructorId)
        {
            const string cacheKeyPrefix = "instructor_courses_";  // Cache prefix for courses by instructor.
            var cacheKey = $"{cacheKeyPrefix}{instructorId}";

            var courseDtos = await _memoryCache.GetDataAsync<IEnumerable<CourseReadByIdDTO>>(cacheKey);

            try
            {
                if (courseDtos == null)
                {
                    // Cache is empty, so retrieve from database.
                    var courses = await _unitOfWork.CourseRepository.GetByCondition(c => c.InstructorId == instructorId);
                    if (!courses.Any())
                        return Ok(Enumerable.Empty<CourseReadByIdDTO>());

                    courseDtos = _mapper.Map<IEnumerable<CourseReadByIdDTO>>(courses);
                    foreach (var courseDto in courseDtos)
                    {
                        courseDto.ThumbnailUrl = ConstructFileUrlHelper.ConstructFileUrl(Request, ThumbnailsFolderName, courseDto.ThumbnailUrl);
                    }

                    await _memoryCache.SetDataAsync(cacheKey, courseDtos, DateTimeOffset.Now.AddMinutes(5));
                }

                return Ok(courseDtos);
            }

            catch (Exception ex)
            {
                _logger.LogError($"An error occured while fetching courses by a specific instructor: {ex.Message}", ex);
                return StatusCode(500, "An error occured while fetching data");
            }

        }

        /// <summary>
        /// Creates a new course with the given details.
        /// </summary>
        /// <param name="courseCreateDto">The course creation request object.</param>
        /// <returns>The created course details.</returns>
        [HttpPost]
        public async Task<ActionResult<CourseReadByIdDTO>> CreateCourse([FromForm] CourseCreateDTO courseCreateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var instructorExists = await _unitOfWork.InstructorRepository.GetByIdAsync(courseCreateDto.InstructorId);
                if (instructorExists == null) return BadRequest("The specified instructor does not exist");

                var imageUrl = await FileUploadHelper.UploadFileAsync(courseCreateDto.Thumbnail, "course-thumbnails");
                var course = _mapper.Map<Course>(courseCreateDto);
                course.ThumbnailUrl = imageUrl;
                await _unitOfWork.CourseRepository.AddAsync(course);
                await _unitOfWork.SaveChangesAsync();
                var courseReadDto = _mapper.Map<CourseReadByIdDTO>(course);

                // Invalidate the cache for all courses after a new course is created.
                await _memoryCache.RemoveDataAsync("all_courses");

                return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, courseReadDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while creating a course: {ex.Message}", ex);
                return StatusCode(500, "An error occurred while creating the course.");
            }
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

            try
            {
                _mapper.Map(courseUpdateDto, course);

                if (courseUpdateDto.Thumbnail != null)
                {
                    FileUploadHelper.DeleteFile(course.ThumbnailUrl);
                    var imageUrl = await FileUploadHelper.UploadFileAsync(courseUpdateDto.Thumbnail, "course-thumbnails");
                    course.ThumbnailUrl = imageUrl;
                }

                await _unitOfWork.CourseRepository.UpdateAsync(course);
                await _unitOfWork.SaveChangesAsync();

                // Invalidate the cache for the specific course.
                await _memoryCache.RemoveDataAsync($"course_{id}");
                // Invalidate the cache for all courses after an update.
                await _memoryCache.RemoveDataAsync("all_courses");

                return Ok(_mapper.Map<CourseReadByIdDTO>(course));
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while updating the course: {ex.Message}", ex);
                return StatusCode(500, "An error occurred while updating the course.");
            }
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
            try
            {
                FileUploadHelper.DeleteFile(course.ThumbnailUrl);
                await _unitOfWork.CourseRepository.DeleteAsync(course);
                await _unitOfWork.SaveChangesAsync();

                // Invalidate the cache for the specific course and all courses.
                await _memoryCache.RemoveDataAsync($"course_{id}");
                await _memoryCache.RemoveDataAsync("all_courses");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while deleting the course: {ex.Message}", ex);
                return StatusCode(500, "An error occurred while deleting the course.");
            }
        }
    }
}
