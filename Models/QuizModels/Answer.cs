using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models.QuizModels
{
    // 3. Answer class - possible answers for each question
    public class Answer : QuizModelsBaseEntity
    {
        public string Text { get; set; } = string.Empty;

        public bool IsCorrect { get; set; } = false;

        public string? Explanation { get; set; }

        public int OrderIndex { get; set; }

        #region Relationships
        [ForeignKey("Question")]
        public string QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public virtual StudentAnswer StudentAnswer { get; set; }
        #endregion
    }
}
