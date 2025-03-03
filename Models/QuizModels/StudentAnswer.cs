using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models.QuizModels
{
    // 5. StudentAnswer class - stores individual student responses
    public class StudentAnswer : QuizModelsBaseEntity
    {
        public string? SubmittedAnswer { get; set; } = string.Empty;

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        public bool IsCorrect { get; set; }
        //[NotMapped]
        //public bool IsCorrect => Answer?.IsCorrect ?? false; // Automatically determine correctness
        #region Relationships
        [ForeignKey("QuizAttemp")]
        public string QuizResultId { get; set; }
        public virtual QuizAttemp QuizResult { get; set; }

        [ForeignKey("Question")]
        public string QuestionId { get; set; }
        public virtual Question Question { get; set; }

        [ForeignKey("Answer")]
        public string AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
        #endregion
    }
}
