using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.DTOs.QuizModelsDTOs.QuizDTOs
{
    public class QuizCreateDTO
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        [Range(1, 90, ErrorMessage = "Duration must be between 1 and 90 minutes")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "LessonId is required")]
        public string LessonId { get; set; }
    }
}
