namespace EdufyAPI.Models.Roles
{
    public class Student : AppUser
    {


        #region Relationships
        // List of courses the student is enrolled in
        public virtual List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>(); // Many-to-Many
        #endregion

    }
}