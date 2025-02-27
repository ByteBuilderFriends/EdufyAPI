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

            // Add image and video URLs to each lesson DTO
            foreach (var lessonDto in lessonDtos)
            {
                //constructs the full URL for the lesson file, allowing the frontend to display it easily
                //Request.Scheme = hhtp/https - Request.Host = localhost:5000 or example.com - Path.GetFileName(lesson.ThumbnailUrl) = Example: image1.jpg
                //For example: https://localhost:5000/lesson-thumbnails/image1.jpg

                // Construct ThumbnailUrl if it exists
                if (!string.IsNullOrEmpty(lessonDto.ThumbnailUrl))
                {
                    lessonDto.ThumbnailUrl = ConstructFileUrl("lesson-thumbnails", lessonDto.ThumbnailUrl);
                }

                // Construct VideoUrl if it exists
                if (!string.IsNullOrEmpty(lessonDto.VideoUrl))
                {
                    lessonDto.VideoUrl = ConstructFileUrl("lesson-videos", lessonDto.VideoUrl);
                }
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

            // Construct ThumbnailUrl if it exists
            if (!string.IsNullOrEmpty(lesson.ThumbnailUrl))
            {
                lessonDto.ThumbnailUrl = ConstructFileUrl("lesson-thumbnails", lesson.ThumbnailUrl);
            }

            // Construct VideoUrl if it exists
            if (!string.IsNullOrEmpty(lesson.VideoUrl))
            {
                lessonDto.VideoUrl = ConstructFileUrl("lesson-videos", lesson.VideoUrl);
            }

            return Ok(lessonDto);
        }

        // POST: api/Lesson
        [HttpPost]
        public async Task<ActionResult<LessonReadDTO>> CreateLesson(LessonCreateDTO createLessonDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);


            // Validate the provided ExternalVideoUrl 
            if (!string.IsNullOrEmpty(createLessonDto.ExternalVideoUrl))
            {
                // Check Format 
                if (!UrlValidatorHelper.IsValidUrlFormat(createLessonDto.ExternalVideoUrl))
                {
                    return BadRequest("Invalid URL format.");
                }

                // Check if URL is reachable 
                var isReachable = await UrlValidatorHelper.IsUrlReachableAsync(createLessonDto.ExternalVideoUrl);
                if (!isReachable)
                {
                    return BadRequest("The provided URL is not reachable.");
                }
            }


            string imageUrl = null;
            string videoUrl = null;

            // Save the thumbnail image if provided
            if (createLessonDto.Thumbnail != null)
            {
                imageUrl = await FileUploadHelper.UploadFileAsync(createLessonDto.Thumbnail, "lesson-thumbnails");
            }

            // Save the video file if provided
            if (createLessonDto.Video != null)
            {
                videoUrl = await FileUploadHelper.UploadFileAsync(createLessonDto.Video, "lesson-videos");
            }

            var lesson = _mapper.Map<Lesson>(createLessonDto);
            lesson.ThumbnailUrl = imageUrl; //Since ThumbnailUrl is generated after saving the image, you still need to assign it manually.
            lesson.VideoUrl = videoUrl;

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

            // Validate the provided ExternalVideoUrl 
            if (!string.IsNullOrEmpty(updateLessonDto.ExternalVideoUrl))
            {
                // Check Format 
                if (!UrlValidatorHelper.IsValidUrlFormat(updateLessonDto.ExternalVideoUrl))
                {
                    return BadRequest("Invalid URL format.");
                }

                // Check if URL is reachable 
                var isReachable = await UrlValidatorHelper.IsUrlReachableAsync(updateLessonDto.ExternalVideoUrl);
                if (!isReachable)
                {
                    return BadRequest("The provided URL is not reachable.");
                }
            }


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