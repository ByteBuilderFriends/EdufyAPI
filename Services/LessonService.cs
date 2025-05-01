using AskAMuslimAPI.Configurations;
using AskAMuslimAPI.Services.Interfaces;
using AutoMapper;
using EdufyAPI.DTOs.LessonDTOs;
using EdufyAPI.Helpers;
using EdufyAPI.Models;
using EdufyAPI.Repository.Interfaces;
using EdufyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AskAMuslimAPI.Services
{
    public class LessonService(
        ICacheService cacheService,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IOptions<CacheSettings> cacheSettings,
        IHttpContextAccessor httpContextAccessor) : ILessonService
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly ICacheService _cacheService = cacheService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly string ThumbnailsFolderName = "lesson-thumbnails";
        private readonly string VideosFolderName = "lesson-videos";
        private readonly CacheSettings _cacheSettings = cacheSettings.Value;

        public async Task<ActionResult<LessonReadDTO>> CreateLesson(LessonCreateDTO createLessonDto)
        {
            if (string.IsNullOrEmpty(createLessonDto.CourseId))
                return new BadRequestObjectResult("Course ID is required.");

            try
            {
                var lesson = _mapper.Map<Lesson>(createLessonDto);
                await _unitOfWork.LessonRepository.AddAsync(lesson);
                await _unitOfWork.SaveChangesAsync();

                var lessonReadDto = _mapper.Map<LessonReadDTO>(lesson);

                // Invalidate cache for the course, and re-fetch the lessons
                await _cacheService.RemoveDataAsync($"CourseLessons_{createLessonDto.CourseId}");
                await _cacheService.RemoveDataAsync("AllLessons");

                return lessonReadDto;
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Error retrieving course: {ex.Message}");
            }
        }

        public async Task<ActionResult<IEnumerable<LessonReadDTO>>> GetAllLessons()
        {
            var lessons = await _unitOfWork.LessonRepository.GetAllAsync();
            if (!lessons.Any())
            {
                return new List<LessonReadDTO>();
            }

            try
            {
                // Check if lessons are cached
                var cachedLessons = await _cacheService.GetDataAsync<IEnumerable<LessonReadDTO>>("AllLessons");
                if (cachedLessons != null)
                {
                    return new ActionResult<IEnumerable<LessonReadDTO>>(cachedLessons);
                }

                var lessonDtos = _mapper.Map<IEnumerable<LessonReadDTO>>(lessons);
                var request = _httpContextAccessor.HttpContext?.Request;

                foreach (var lessonDto in lessonDtos)
                {

                    if (!string.IsNullOrEmpty(lessonDto.ThumbnailUrl))
                    {
                        lessonDto.ThumbnailUrl = ConstructFileUrlHelper.ConstructFileUrl(request, ThumbnailsFolderName, lessonDto.ThumbnailUrl);
                    }

                    if (!string.IsNullOrEmpty(lessonDto.VideoUrl))
                    {
                        lessonDto.VideoUrl = ConstructFileUrlHelper.ConstructFileUrl(request, VideosFolderName, lessonDto.VideoUrl);
                    }

                    await _cacheService.SetDataAsync($"Lesson_{lessonDto.Id}", lessonDto, DateTimeOffset.Now.AddMinutes(_cacheSettings.LessonCacheMinutes));
                    await _cacheService.SetDataAsync($"CourseLessons_{lessonDto.CourseId}", lessonDtos, DateTimeOffset.Now.AddMinutes(_cacheSettings.LessonCacheMinutes));
                }

                // Cache the lessons
                await _cacheService.SetDataAsync("AllLessons", lessonDtos, DateTimeOffset.Now.AddMinutes(_cacheSettings.LessonCacheMinutes));

                return new ActionResult<IEnumerable<LessonReadDTO>>(lessonDtos);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Error retrieving lessons: {ex.Message}");
            }

        }

        public Task<ActionResult<IEnumerable<LessonReadDTO>>> GetCourseLessons(string courseId)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<LessonReadDTO>> GetLessonByID(string id)
        {
            throw new NotImplementedException();
        }
        public Task<IActionResult> UpdateLesson(string id, LessonUpdateDTO updateLessonDto)
        {
            throw new NotImplementedException();
        }
        public Task<IActionResult> DeleteLesson(string id)
        {
            throw new NotImplementedException();
        }


    }
}
