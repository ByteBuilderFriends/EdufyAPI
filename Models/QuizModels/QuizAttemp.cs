using EdufyAPI.Models.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models.QuizModels
{

    // 4. QuizAttemp class - stores overall quiz attempt results
    public class QuizAttemp : QuizModelsBaseEntity
    {
        [Required]
        public double Score { get; set; }

        public double ScorePercentage => (double)(Quiz?.TotalPoints == 0 ? 0 : (double)Score / Quiz?.TotalPoints * 100);
        public bool IsPassed => ScorePercentage >= Quiz?.PassingScore;

        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }

        public TimeSpan Duration => (CompletedAt ?? DateTime.UtcNow) - StartedAt;

        #region Relationships
        [ForeignKey("Progress")]
        public string ProgressId { get; set; }
        public virtual Progress Progress { get; set; }

        [ForeignKey("Quiz")]
        public string QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }

        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }

        public virtual List<StudentAnswer> StudentAnswers { get; set; } = new();
        #endregion
    }
}
