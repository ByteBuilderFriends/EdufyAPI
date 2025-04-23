using AskAMuslimAPI.Enums;
using EdufyAPI.DTOs.LessonDTOs;

namespace EdufyAPI.DTOs
{
    public class CourseReadDTO
    {
        public string Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;

        public CourseCategory Category { get; set; }
        //public string CategoryName => Category.ToString();

        public CourseLevel Level { get; set; }

        public string InstructorID { get; set; }
        public ICollection<LessonReadDTO> Lessons { get; set; }

        // Add number of students enrolled here
        public int NumberOfStudentsEnrolled { get; set; } = 0;
    }
}
