using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models.QuizModels
{
    // 1. Main Quiz class - parent container
    public class Quiz : QuizModelsBaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        [Range(0, 100)]
        public int PassingScore { get; set; } = 50;

        [Range(0, 300)]
        public int TimeLimit { get; set; } = 0;

        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public int TotalQuestions => Questions?.Count ?? 0;
        public int TotalPoints => Questions?.Sum(q => q.Points) ?? 0;

        #region Relationships
        [ForeignKey("Lesson")]
        public string LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public virtual List<Question> Questions { get; set; } = new();
        public virtual List<QuizAttemp> QuizResult { get; set; } = new();
        #endregion
    }
}
