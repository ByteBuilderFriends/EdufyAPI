namespace EdufyAPI.Models.Roles
{
    public class Instructor : User
    {
        // One instructor can create multiple courses
        public List<Course> CoursesCreated { get; set; } = new List<Course>();
    }
}
