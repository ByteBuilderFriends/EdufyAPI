using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models.QuizModels
{
    // 2. Question class - contains the actual questions
    public class Question : QuizModelsBaseEntity
    {
        [Required]
        public string Text { get; set; } = string.Empty;

        public string? Explanation { get; set; }

        [Range(1, 100)]
        public int Points { get; set; } = 1;

        public QuestionType Type { get; set; } = QuestionType.SingleChoice;

        public int OrderIndex { get; set; }

        public string Answer { get; set; } = string.Empty;

        #region Relationships
        [ForeignKey("Quiz")]
        public string QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }

        public virtual List<Answer> Answers { get; set; } = new();
        public virtual List<StudentAnswer> StudentAnswers { get; set; } = new();
        #endregion
    }
}
