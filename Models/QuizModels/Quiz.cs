using EdufyAPI.Models.Roles;
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
        public int Duration { get; set; }

        //Quiz Attempt
        public int StudentQuizEvaluation { get; set; } = 0;
        public int StudentQuizResult { get; set; } = 0;

        #region Relationships
        [Required]
        public string LessonId { get; set; }

        public virtual Lesson Lesson { get; set; } = new Lesson();

        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; } = string.Empty;
        public virtual Student Student { get; set; } = new Student();


        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
        #endregion

    }
}
