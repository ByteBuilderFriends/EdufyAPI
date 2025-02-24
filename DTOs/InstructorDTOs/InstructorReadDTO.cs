using EdufyAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.DTOs.InstructorDTOs
{
    public class InstructorReadDTO
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        // Add courses taught here
        [NotMapped]
        public List<Course> Courses { get; set; } = new();

        public List<string> CoursesTaught
        {
            get
            {
                return Courses.Where(c => c.InstructorId == Id).Select(c => $"{c.Title}: {c.Description}").ToList();
            }
        }


        public int CourseCount
        {
            get
            {
                return CoursesTaught.Count;
            }
        }

    }
}
