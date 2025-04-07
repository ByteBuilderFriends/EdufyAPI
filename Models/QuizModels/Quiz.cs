using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models.QuizModels
{
    public class Quiz
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int TotalQuestions { get; set; } = 0;

        public int TotalMarks { get; set; } = 0;

        //Quiz Attempt
        public int StudentQuizEvaluation { get; set; } = 0;
        public int StudentQuizResult { get; set; } = 0;

        #region Relationships
        [Required]
        [ForeignKey(nameof(Lesson))]
        public string LessonId { get; set; } = string.Empty;
        public virtual Lesson Lesson { get; set; }

        //[ForeignKey(nameof(Student))]
        //public string? StudentId { get; set; } = string.Empty;
        //public virtual Student? Student { get; set; }


        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
        #endregion

    }
}
