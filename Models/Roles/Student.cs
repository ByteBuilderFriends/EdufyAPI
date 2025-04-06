using EdufyAPI.Models.QuizModels;

namespace EdufyAPI.Models.Roles
{
    public class Student : AppUser
    {


        #region Relationships

        public virtual List<Quiz> Quizzes { get; set; } = new List<Quiz>(); // One-to-Many
        public virtual List<Enrollment> Enrollments { get; set; } = new List<Enrollment>(); // Many-to-Many
        public virtual List<Progress> Progresses { get; set; } = new List<Progress>();
        public virtual List<Answer> Answers { get; set; } = new List<Answer>();
        #endregion

    }
}