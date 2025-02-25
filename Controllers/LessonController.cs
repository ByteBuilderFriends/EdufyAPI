using AutoMapper;
using EdufyAPI.DTOs.LessonDTOs;
using EdufyAPI.Helpers;
using EdufyAPI.Models;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LessonController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Lesson
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonReadDTO>>> GetLessons()
        {
            var lessons = await _unitOfWork.LessonRepository.GetAllAsync();
            if (!lessons.Any())
            {
                return Ok(Enumerable.Empty<LessonReadDTO>());
            }

            var lessonDtos = _mapper.Map<IEnumerable<LessonReadDTO>>(lessons);

            // Add image URLs to each lesson DTO
            foreach (var lessonDto in lessonDtos)
            {
                //constructs the full URL for the lesson image, allowing the frontend to display it easily
                //Request.Scheme = hhtp/https - Request.Host = localhost:5000 or example.com - Path.GetFileName(lesson.ThumbnailUrl) = Example: image1.jpg
                //For example: https://localhost:5000/lesson-thumbnails/image1.jpg
                lessonDto.ThumbnailUrl = $"{Request.Scheme}://{Request.Host}/lesson-thumbnails/{Path.GetFileName(lessonDto.ThumbnailUrl)}";
            }
            return Ok(lessonDtos);
        }

        // GET: api/Lesson/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<LessonReadDTO>> GetLessonByID(string id)
        {
            var lesson = await _unitOfWork.LessonRepository.GetByIdAsync(id);
            if (lesson == null) return NotFound("Lesson not found.");

            var lessonDto = _mapper.Map<LessonReadDTO>(lesson);

            //constructs the full URL for the lesson image, allowing the frontend to display it easily
            //Request.Scheme = hhtp/https - Request.Host = localhost:5000 or example.com - Path.GetFileName(lesson.ThumbnailUrl) = Example: image1.jpg
            //For example: https://localhost:5000/lesson-thumbnails/image1.jpg
            var imageUrl = $"{Request.Scheme}://{Request.Host}/lesson-thumbnails/{Path.GetFileName(lesson.ThumbnailUrl)}";
            lessonDto.ThumbnailUrl = imageUrl;

            return Ok(lessonDto);
        }

        // POST: api/Lesson
        [HttpPost]
        public async Task<ActionResult<LessonReadDTO>> CreateLesson(LessonCreateDTO createLessonDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Save the thumbnail image and get the URL
            var imageUrl = await ImageHelper.SaveImageAsync(createLessonDto.Thumbnail, "lesson-thumbnails");

            var lesson = _mapper.Map<Lesson>(createLessonDto);
            lesson.ThumbnailUrl = imageUrl; //Since ThumbnailUrl is generated after saving the image, you still need to assign it manually.

            await _unitOfWork.LessonRepository.AddAsync(lesson);
            await _unitOfWork.SaveChangesAsync();

            var lessonReadDto = _mapper.Map<LessonReadDTO>(lesson);
            return CreatedAtAction(nameof(GetLessonByID), new { id = lesson.Id }, lessonReadDto);
        }

        // PUT: api/Lesson/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLesson(string id, LessonUpdateDTO updateLessonDto)
        {
            var lesson = await _unitOfWork.LessonRepository.GetByIdAsync(id);
            if (lesson == null) return NotFound("Lesson not found.");

            _mapper.Map(updateLessonDto, lesson);

            if (updateLessonDto.Thumbnail != null)
            {
                ImageHelper.DeleteImage(lesson.ThumbnailUrl, "lesson-thumbnails");  // Delete the old image if exists
                var imageUrl = await ImageHelper.SaveImageAsync(updateLessonDto.Thumbnail, "lesson-thumbnails");
                lesson.ThumbnailUrl = imageUrl;
            }

            await _unitOfWork.LessonRepository.UpdateAsync(lesson);
            await _unitOfWork.SaveChangesAsync();

            return Ok(_mapper.Map<LessonReadDTO>(lesson));
        }

        // DELETE: api/Lesson/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(string id)
        {
            var lesson = await _unitOfWork.LessonRepository.GetByIdAsync(id);
            if (lesson == null) return NotFound("Lesson not found.");

            // Delete the image from the server
            ImageHelper.DeleteImage(lesson.ThumbnailUrl, "lesson-thumbnails");

            // Remove the lesson from the database
            await _unitOfWork.LessonRepository.DeleteAsync(lesson);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}