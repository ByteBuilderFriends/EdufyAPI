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

        // Centralized URL Construction Method
        private string ConstructFileUrl(string folder, string fileName)
        {
            return $"{Request.Scheme}://{Request.Host}/{folder}/{Path.GetFileName(fileName)}";
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
                //constructs the full URL for the lesson file, allowing the frontend to display it easily
                //Request.Scheme = hhtp/https - Request.Host = localhost:5000 or example.com - Path.GetFileName(lesson.ThumbnailUrl) = Example: image1.jpg
                //For example: https://localhost:5000/lesson-thumbnails/image1.jpg
                lessonDto.ThumbnailUrl = ConstructFileUrl("lesson-thumbnails", lessonDto.ThumbnailUrl);
                lessonDto.VideoUrl = ConstructFileUrl("lesson-videos", lessonDto.VideoUrl);
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
            lessonDto.ThumbnailUrl = ConstructFileUrl("lesson-thumbnails", lesson.ThumbnailUrl);
            lessonDto.VideoUrl = ConstructFileUrl("lesson-videos", lesson.VideoUrl);

            return Ok(lessonDto);
        }

        // POST: api/Lesson
        [HttpPost]
        public async Task<ActionResult<LessonReadDTO>> CreateLesson(LessonCreateDTO createLessonDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Save the thumbnail image and get the URL
            var imageUrl = await FileUploadHelper.UploadFileAsync(createLessonDto.Thumbnail, "lesson-thumbnails");
            var videoUrl = await FileUploadHelper.UploadFileAsync(createLessonDto.Video, "lesson-videos");

            var lesson = _mapper.Map<Lesson>(createLessonDto);
            lesson.ThumbnailUrl = imageUrl; //Since ThumbnailUrl is generated after saving the image, you still need to assign it manually.
            lesson.VideoUrl = videoUrl;

            await _unitOfWork.LessonRepository.AddAsync(lesson);
            await _unitOfWork.SaveChangesAsync();

            var lessonReadDto = _mapper.Map<LessonReadDTO>(lesson);
            //lessonReadDto.ThumbnailUrl = ConstructFileUrl("lesson-thumbnails", lesson.ThumbnailUrl);
            //lessonReadDto.VideoUrl = ConstructFileUrl("lesson-videos", lesson.VideoUrl);

            return CreatedAtAction(nameof(GetLessonByID), new { id = lesson.Id }, lessonReadDto);
        }

        // PUT: api/Lesson/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLesson(string id, LessonUpdateDTO updateLessonDto)
        {
            var lesson = await _unitOfWork.LessonRepository.GetByIdAsync(id);
            if (lesson == null) return NotFound("Lesson not found.");

            _mapper.Map(updateLessonDto, lesson);

            // Handle thumbnail update
            if (updateLessonDto.Thumbnail != null)
            {
                FileUploadHelper.DeleteFile(lesson.ThumbnailUrl);  // Delete the old image if exists
                var imageUrl = await FileUploadHelper.UploadFileAsync(updateLessonDto.Thumbnail, "lesson-thumbnails");
                lesson.ThumbnailUrl = imageUrl;
            }
            // Handle video update
            if (updateLessonDto.Video != null)
            {
                FileUploadHelper.DeleteFile(lesson.VideoUrl);  // Delete the old video if exists
                var videoUrl = await FileUploadHelper.UploadFileAsync(updateLessonDto.Video, "lesson-video");
                lesson.VideoUrl = videoUrl;
            }

            await _unitOfWork.LessonRepository.UpdateAsync(lesson);
            await _unitOfWork.SaveChangesAsync();

            var lessonReadDto = _mapper.Map<LessonReadDTO>(lesson);
            //lessonReadDto.ThumbnailUrl = ConstructFileUrl("lesson-thumbnails", lesson.ThumbnailUrl);
            //lessonReadDto.VideoUrl = ConstructFileUrl("lesson-videos", lesson.VideoUrl);
            return Ok(lessonReadDto);
        }

        // DELETE: api/Lesson/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(string id)
        {
            var lesson = await _unitOfWork.LessonRepository.GetByIdAsync(id);
            if (lesson == null) return NotFound("Lesson not found.");

            // Delete the image from the server
            FileUploadHelper.DeleteFile(lesson.ThumbnailUrl);
            // Delete the video from the server
            FileUploadHelper.DeleteFile(lesson.VideoUrl);

            // Remove the lesson from the database
            await _unitOfWork.LessonRepository.DeleteAsync(lesson);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}