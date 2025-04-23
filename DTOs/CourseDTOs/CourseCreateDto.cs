using AskAMuslimAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.DTOs.CourseDTOs
{
    public class CourseCreateDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public CourseCategory? Category { get; set; } = CourseCategory.Other;
        public CourseLevel? Level { get; set; } = CourseLevel.AllLevels;
        public IFormFile? Thumbnail { get; set; }

        [Required]
        public string InstructorId { get; set; }
    }
}
