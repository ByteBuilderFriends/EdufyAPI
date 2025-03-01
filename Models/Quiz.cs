using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models
{
    // Base class for common properties
    public abstract class BaseEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public string CreatedBy { get; set; } = "System";
        public string? UpdatedBy { get; set; }
    }

    // 1. Main Quiz class - parent container
    public class Quiz : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;
        //[NotMapped]
        //public string Title => string.IsNullOrEmpty(InternalTitle) ? $"{Lesson?.Title ?? "Untitled"} Quiz" : InternalTitle;

        //[NotMapped]
        //public string Title
        //{
        //    get => string.IsNullOrEmpty(InternalTitle) ? $"{Lesson?.Title ?? "Untitled"} Quiz" : InternalTitle;
        //    set => InternalTitle = string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();
        //}

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
        public virtual List<QuizResult> QuizResult { get; set; } = new();
        #endregion
    }

    // 2. Question class - contains the actual questions
    public class Question : BaseEntity
    {
        [Required]
        public string Text { get; set; } = string.Empty;

        public string? Explanation { get; set; }

        [Range(1, 100)]
        public int Points { get; set; } = 1;

        public QuestionType Type { get; set; } = QuestionType.SingleChoice;

        public int OrderIndex { get; set; }

        #region Relationships
        [ForeignKey("Quiz")]
        public string QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }

        public virtual List<Answer> Answers { get; set; } = new();
        public virtual List<StudentAnswer> StudentAnswers { get; set; } = new();
        #endregion
    }

    // 3. Answer class - possible answers for each question
    public class Answer : BaseEntity
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

    // 4. QuizResult class - stores overall quiz attempt results
    public class QuizResult : BaseEntity
    {
        [Required]
        public int Score { get; set; }

        //public double ScorePercentage => Quiz?.TotalPoints == 0 ? 0 : (double)Score / Quiz?.TotalPoints * 100;
        //public bool IsPassed => ScorePercentage >= Quiz?.PassingScore;

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

        public virtual List<StudentAnswer> StudentAnswers { get; set; } = new();
        #endregion
    }

    // 5. StudentAnswer class - stores individual student responses
    public class StudentAnswer : BaseEntity
    {
        public string? SubmittedAnswer { get; set; } = string.Empty;

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        public bool IsCorrect { get; set; }
        //[NotMapped]
        //public bool IsCorrect => Answer?.IsCorrect ?? false; // Automatically determine correctness
        #region Relationships
        [ForeignKey("QuizResult")]
        public string QuizResultId { get; set; }
        public virtual QuizResult QuizResult { get; set; }

        [ForeignKey("Question")]
        public string QuestionId { get; set; }
        public virtual Question Question { get; set; }

        [ForeignKey("Answer")]
        public string AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
        #endregion
    }
}