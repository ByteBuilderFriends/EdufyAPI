using AskAMuslimAPI.Services.Interfaces;
using AutoMapper;
using EdufyAPI.DTOs.LessonDTOs;
using EdufyAPI.Helpers;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly string ThumbnailsFolderName = "lesson-thumbnails";
        private readonly string VideosFolderName = "lesson-videos";

        public LessonController(IUnitOfWork unitOfWork, IMapper mapper, ILessonService lessonService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _lessonService = lessonService;
        }

        /// <summary>
        /// Creates a new lesson.
        /// </summary>
        /// <param name="createLessonDto">The lesson data.</param>
        /// <returns>The created lesson.</returns>
        [HttpPost]
        public async Task<ActionResult<LessonReadDTO>> CreateLesson(LessonCreateDTO createLessonDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var lesson = _lessonService.CreateLesson(createLessonDto);
            return CreatedAtAction(nameof(GetLessonByID), new { id = lesson.Id }, lesson);
        }

        /// <summary>
        /// Retrieves all lessons.
        /// </summary>
        /// <returns>A list of lessons with their details.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LessonReadDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<LessonReadDTO>>> GetAllLessons()
        {
            return await _lessonService.GetAllLessons();
        }

        /// <summary>
        /// Retrieves a specific lesson by ID.
        /// </summary>
        /// <param name="id">The lesson ID.</param>
        /// <returns>The lesson details.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<LessonReadDTO>> GetLessonByID(string id)
        {
            var lesson = await _unitOfWork.LessonRepository.GetByIdAsync(id);
            if (lesson == null) return NotFound("Lesson not found.");

            var lessonDto = _mapper.Map<LessonReadDTO>(lesson);
            if (!string.IsNullOrEmpty(lesson.ThumbnailUrl))
            {
                lessonDto.ThumbnailUrl = ConstructFileUrlHelper.ConstructFileUrl(Request, ThumbnailsFolderName, lesson.ThumbnailUrl);
            }
            if (!string.IsNullOrEmpty(lesson.VideoUrl))
            {
                lessonDto.VideoUrl = ConstructFileUrlHelper.ConstructFileUrl(Request, VideosFolderName, lesson.VideoUrl);
            }
            return Ok(lessonDto);
        }

        /// <summary>
        /// Retrieves all lessons for a specific course.
        /// </summary>
        /// <param name="courseId">The course ID.</param>
        /// <returns>A list of lessons.</returns>
        [HttpGet("{courseId}")]
        public async Task<ActionResult<IEnumerable<LessonReadDTO>>> GetCourseLessons(string courseId)
        {
            var lessons = await _unitOfWork.LessonRepository.GetByCondition(l => l.CourseId == courseId);
            if (!lessons.Any())
            {
                return Ok(Enumerable.Empty<LessonReadDTO>());
            }

            var lessonDtos = _mapper.Map<IEnumerable<LessonReadDTO>>(lessons);
            foreach (var lessonDto in lessonDtos)
            {
                if (!string.IsNullOrEmpty(lessonDto.ThumbnailUrl))
                {
                    lessonDto.ThumbnailUrl = ConstructFileUrlHelper.ConstructFileUrl(Request, ThumbnailsFolderName, lessonDto.ThumbnailUrl);
                }
                if (!string.IsNullOrEmpty(lessonDto.VideoUrl))
                {
                    lessonDto.VideoUrl = ConstructFileUrlHelper.ConstructFileUrl(Request, VideosFolderName, lessonDto.VideoUrl);
                }
            }
            return Ok(lessonDtos);
        }



        /// <summary>
        /// Updates an existing lesson.
        /// </summary>
        /// <param name="id">The lesson ID.</param>
        /// <param name="updateLessonDto">The updated lesson data.</param>
        /// <returns>The updated lesson.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLesson(string id, LessonUpdateDTO updateLessonDto)
        {
            var lesson = await _unitOfWork.LessonRepository.GetByIdAsync(id);
            if (lesson == null) return NotFound("Lesson not found.");

            _mapper.Map(updateLessonDto, lesson);
            await _unitOfWork.LessonRepository.UpdateAsync(lesson);
            await _unitOfWork.SaveChangesAsync();

            var lessonReadDto = _mapper.Map<LessonReadDTO>(lesson);
            return Ok(lessonReadDto);
        }

        /// <summary>
        /// Deletes a lesson by ID.
        /// </summary>
        /// <param name="id">The lesson ID.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(string id)
        {
            var lesson = await _unitOfWork.LessonRepository.GetByIdAsync(id);
            if (lesson == null) return NotFound("Lesson not found.");

            await _unitOfWork.LessonRepository.DeleteAsync(lesson);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
