using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.DTOs.LessonDTOs
{
    public class LessonUpdateDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public IFormFile? Thumbnail { get; set; }
        public IFormFile? Video { get; set; }

        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string? ExternalVideoUrl { get; set; }


    }
}
