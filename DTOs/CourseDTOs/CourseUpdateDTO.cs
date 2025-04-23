using AskAMuslimAPI.Enums;

namespace EdufyAPI.DTOs.CourseDTOs
{
    public class CourseUpdateDTO
    {
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public CourseCategory? Category { get; set; } = CourseCategory.Other;
        public CourseLevel? Level { get; set; } = CourseLevel.AllLevels;
        public IFormFile? Thumbnail { get; set; }
    }
}
