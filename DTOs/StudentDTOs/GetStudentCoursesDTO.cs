using EdufyAPI.Models;

namespace EdufyAPI.DTOs.StudentDTOs
{
    public class GetStudentCoursesDTO
    {
        public string StudentId { get; set; }

        //public Dictionary<string, string> Courses { get; set; }

        public List<Course> courses { get; set; } = new List<Course>();

        //public List<string> CoursesTitle { get; set; } = new List<string>();

    }
}
