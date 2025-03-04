using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.DTOs.QuizModelsDTOs.QuestionDTOs
{
    public class QuestionCreateDTO
    {
        [Required]
        public string Text { get; set; } = string.Empty;

        public string? Explanation { get; set; }

        [Range(1, 100)]
        public int Points { get; set; } = 1;

        public QuestionType Type { get; set; } = QuestionType.SingleChoice;

        public int OrderIndex { get; set; }

        [Required]
        public string QuizId { get; set; } = string.Empty;

        public string Answer { get; set; } = string.Empty;
    }
}
