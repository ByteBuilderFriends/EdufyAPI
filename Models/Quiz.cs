using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models
{
    // 1. Main Quiz class - parent container
    public class Quiz
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string _title { get; set; } = string.Empty;

        [Required]
        public string Title
        {
            get => string.IsNullOrEmpty(_title) ? $"{Lesson?.Title ?? "Untitled"} Quiz" : _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _title = string.Empty; // Will use default format
                }
                else
                {
                    _title = value.Trim(); // Delete whitespace and set the value
                }
            }
        }

        public string? Description { get; set; }

        [Range(0, 100)]
        public int PassingScore { get; set; } = 50; // Percentage required to pass

        [Range(0, 300)]
        public int TimeLimit { get; set; } = 0; // Time limit in minutes (0 = no limit)

        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false; // Soft deletion flag
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; } = "System"; // Audit field
        public string? UpdatedBy { get; set; } // Audit field

        // Computed properties
        public int TotalQuestions => Questions?.Count ?? 0;
        public int TotalPoints => Questions?.Sum(q => q.Points) ?? 0;

        #region Relationships
        [ForeignKey("Lesson")]
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        [InverseProperty("Quiz")]
        public virtual List<Question> Questions { get; set; } = new List<Question>();

        [InverseProperty("Quiz")]
        public virtual List<QuizResult> QuizResults { get; set; } = new List<QuizResult>();
        #endregion
    }

    // 2. Question Types Enum - defines available question formats
    public enum QuestionType
    {
        SingleChoice,   //Select only one answer from a list of options.
        MultipleChoice, //Select more than one answer from a list.
        TrueFalse,
        ShortAnswer
    }

    // 3. Question class - contains the actual questions
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;

        public string? Explanation { get; set; }

        [Range(1, 100)]
        public int Points { get; set; } = 1;

        public QuestionType Type { get; set; } = QuestionType.SingleChoice;

        public int OrderIndex { get; set; }

        #region Relationships
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }

        [InverseProperty("Question")]
        public virtual List<Answer> Answers { get; set; } = new List<Answer>();
        #endregion
    }

    // 4. Answer class - possible answers for each question
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;

        public bool IsCorrect { get; set; } = false;

        public string? Explanation { get; set; }

        public int OrderIndex { get; set; }

        #region Relationships
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        [InverseProperty("Answer")]
        public virtual List<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();
        #endregion
    }

    // 5. QuizResult class - stores overall quiz attempt results
    public class QuizResult
    {
        public int Id { get; set; }

        [Required]
        public int Score { get; set; }

        public double ScorePercentage => Quiz.TotalPoints == 0 ? 0 : (double)Score / Quiz.TotalPoints * 100;

        public bool IsPassed => ScorePercentage >= Quiz.PassingScore;

        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }

        public TimeSpan Duration => (CompletedAt ?? DateTime.UtcNow) - StartedAt;

        #region Relationships
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }

        [ForeignKey("Progress")]
        public int ProgressId { get; set; }
        public virtual Progress Progress { get; set; }

        [InverseProperty("QuizResult")]
        public virtual List<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();
        #endregion
    }

    // 6. StudentAnswer class - stores individual student responses
    public class StudentAnswer
    {
        public int Id { get; set; }

        public string? SubmittedAnswer { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        public bool IsCorrect { get; set; }

        #region Relationships
        [ForeignKey("QuizResult")]
        public int QuizResultId { get; set; }
        public virtual QuizResult QuizResult { get; set; }

        [ForeignKey("Answer")]
        public int? AnswerId { get; set; }
        public virtual Answer? Answer { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        #endregion
    }
}