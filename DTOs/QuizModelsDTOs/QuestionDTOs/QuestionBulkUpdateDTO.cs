using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.DTOs.QuizModelsDTOs.QuestionDTOs
{
    public class QuestionBulkUpdateDTO
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;

        public string? Explanation { get; set; }

        [Range(1, 100)]
        public int Points { get; set; } = 1;

        public QuestionType Type { get; set; }

        public int OrderIndex { get; set; }
    }
}
