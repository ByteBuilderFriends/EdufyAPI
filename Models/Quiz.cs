using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public int TotalQuestions => Questions.Count; // Derived property for convenience

        #region Relationships
        [ForeignKey("Lesson")]
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public virtual List<Question> Questions { get; set; } = new List<Question>();
        #endregion
    }

    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;

        #region Relationships
        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }

        public virtual List<Answer> Answers { get; set; } = new List<Answer>();
        #endregion

    }

    public class Answer
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;

        public bool IsCorrect { get; set; } = false;

        #region Relationships

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        #endregion

    }

    public class QuizResult
    {
        public int Id { get; set; }

        [Required]
        public int Score { get; set; } // Total score of the quiz attempt
        public DateTime CompletedAt { get; set; } = DateTime.UtcNow; // Timestamp when the quiz was completed

        //public bool IsPassed => Score >= PassingScore; // Auto-calculated based on threshold

        //public int TotalCorrectAnswers => StudentAnswers.Count(sa => sa.IsCorrect);

        //[NotMapped]
        //public int PassingScore => Quiz.TotalQuestions / 2; // Pass threshold (50% correct)

        #region Relationships
        [ForeignKey("Progress")]
        public int ProgressId { get; set; }
        public virtual Progress Progress { get; set; }
        public virtual List<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();
        #endregion
    }

    public class StudentAnswer
    {
        public int Id { get; set; }

        //[NotMapped]
        //public bool IsCorrect => Answer?.IsCorrect ?? false; // Automatically determine correctness

        #region Relationships
        [ForeignKey("QuizResult")]
        public int QuizResultId { get; set; }
        public virtual QuizResult QuizResult { get; set; }
        #endregion

    }
}