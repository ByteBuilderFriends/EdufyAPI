using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.DTOs.LessonDTOs
{
    public class LessonUpdateDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public IFormFile? Thumbnail { get; set; }

    }
}
