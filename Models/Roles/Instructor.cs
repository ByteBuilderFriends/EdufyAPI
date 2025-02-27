namespace EdufyAPI.Models.Roles
{
    public class Instructor : AppUser
    {

        #region Relationships
        public virtual List<Course> Courses { get; set; } = new List<Course>();
        #endregion
    }
}