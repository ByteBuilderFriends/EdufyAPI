using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.DTOs.QuizModelsDTOs.QuizDTOs
{
    public class QuizCreateDTO
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "LessonId is required")]
        public string LessonId { get; set; }
    }
}
