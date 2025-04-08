using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.DTOs.QuizModelsDTOs.AnswerDTOs
{
    public class AnswerCreateDTO
    {
        [Required]
        public string StudentId { get; set; } = string.Empty;
        [Required]
        public string QuestionId { get; set; } = string.Empty;
        [Required]
        public string SelectedOptionId { get; set; } = string.Empty;
    }
}
