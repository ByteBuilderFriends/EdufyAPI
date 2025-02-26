using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.DTOs.LessonDTOs
{
    public class LessonCreateDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        [Required]
        public string CourseId { get; set; }
        public IFormFile Thumbnail { get; set; }
        public IFormFile Video { get; set; }

    }
}
