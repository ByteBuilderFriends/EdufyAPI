using EdufyAPI.DTOs.LessonDTOs;
using Microsoft.AspNetCore.Mvc;

namespace AskAMuslimAPI.Services.Interfaces
{
    public interface ILessonService
    {
        Task<ActionResult<LessonReadDTO>> CreateLesson(LessonCreateDTO createLessonDto);
        Task<ActionResult<IEnumerable<LessonReadDTO>>> GetAllLessons();
        Task<ActionResult<LessonReadDTO>> GetLessonByID(string id);

        Task<ActionResult<IEnumerable<LessonReadDTO>>> GetCourseLessons(string courseId);

        Task<IActionResult> UpdateLesson(string id, LessonUpdateDTO updateLessonDto);

        Task<IActionResult> DeleteLesson(string id);
    }
}
