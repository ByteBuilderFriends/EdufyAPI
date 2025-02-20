using EdufyAPI.Models.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Lesson")]
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public virtual List<Question> Questions { get; set; } = new List<Question>();

        public int TotalQuestions => Questions.Count; // Derived property for convenience
    }

    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;

        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }

        public virtual List<Answer> Answers { get; set; } = new List<Answer>();
    }

    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;

        public bool IsCorrect { get; set; } = false;

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }

    public class QuizResult
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Quiz")]
        public int QuizId { get; set; }
        public virtual Quiz Quiz { get; set; }

        [Required]
        public int Score { get; set; } // Total score of the quiz attempt

        public DateTime CompletedAt { get; set; } = DateTime.UtcNow; // Timestamp when the quiz was completed

        public bool IsPassed => Score >= PassingScore; // Auto-calculated based on threshold

        public virtual List<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();

        public int TotalCorrectAnswers => StudentAnswers.Count(sa => sa.IsCorrect);

        [NotMapped]
        public int PassingScore => Quiz.TotalQuestions / 2; // Pass threshold (50% correct)
    }

    public class StudentAnswer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("QuizResult")]
        public int QuizResultId { get; set; }
        public virtual QuizResult QuizResult { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        [ForeignKey("Answer")]
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }

        [NotMapped]
        public bool IsCorrect => Answer?.IsCorrect ?? false; // Automatically determine correctness
    }
}
