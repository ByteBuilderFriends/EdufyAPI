using EdufyAPI.Models.QuizModels;

namespace EdufyAPI.Models.Roles
{
    public class Student : AppUser
    {


        #region Relationships
        // List of courses the student is enrolled in
        public virtual List<Enrollment> Enrollments { get; set; } = new List<Enrollment>(); // Many-to-Many
        public virtual List<Progress> Progresses { get; set; } = new List<Progress>();
        public virtual List<QuizAttemp> QuizAttemps { get; set; } = new List<QuizAttemp>();

        #endregion

    }
}