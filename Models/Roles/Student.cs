namespace EdufyAPI.Models.Roles
{
    public class Student : AppUser
    {


        #region Relationships
        // List of courses the student is enrolled in
        public virtual List<Enrollment> Enrollments { get; set; } = new List<Enrollment>(); // Many-to-Many
        #endregion

    }
}