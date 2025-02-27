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

        // ✅ Make it a property
        public List<string> EnrolledCourses { get; set; } = new();

        // ✅ Fix CompletedCourses logic
        public List<string> CompletedCourses { get; set; } = new();

        // ✅ Add CourseCount since it's mapped in AutoMapper
        public int CourseCount { get; set; }

        public string ProfilePictureUrl { get; set; } = string.Empty;

        // NOTE: I neeed to thing about how the student will enrollCourse, remember is related to StudentCourse

    }
}
