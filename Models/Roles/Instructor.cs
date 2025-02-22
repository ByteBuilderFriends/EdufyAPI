namespace EdufyAPI.Models.Roles
{
    public class Instructor : AppUser
    {

        #region Relationships
        public virtual List<Course> CoursesCreated { get; set; } = new List<Course>();
        #endregion
    }
}