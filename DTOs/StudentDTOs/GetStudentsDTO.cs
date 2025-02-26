using EdufyAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EdufyAPI.DTOs.StudentDTOs
{
    public class GetStudentsDTO
    {
        public string Id { get; set; }

        [JsonIgnore]
        public string FirstName { get; set; }

        [JsonIgnore]
        public string LastName { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [NotMapped]
        private List<StudentCourse> EnrolledCourses = new();

        public List<string> CompletedCourses
        {
            get
            {
                return EnrolledCourses.Where(x => x.Course.CourseProgress.All(y => y.IsCompleted)).Select(x => x.Course.Title).ToList();
            }
        }

    }
}
