using EdufyAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EdufyAPI.DTOs.InstructorDTOs
{
    public class InstructorReadDTO
    {
        public string Id { get; set; }

        [JsonIgnore]
        [Required]
        public string? FirstName { get; set; } = string.Empty;

        [JsonIgnore]
        [Required]

        public string? LastName { get; set; } = string.Empty;

        public string FullName { get; set; }

        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        // Add courses taught here
        [NotMapped]
        [JsonIgnore]
        public List<Course> _courses { get; set; } = new();

        public List<string> Courses
        {
            get
            {
                return _courses.Where(c => c.InstructorId == Id).Select(c => $"{c.Title}: {c.Description}").ToList();
            }
        }


        public int CourseCount
        {
            get
            {
                return Courses.Count;
            }
        }

    }
}
