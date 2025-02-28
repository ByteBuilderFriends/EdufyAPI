using EdufyAPI.DTOs.LessonDTOs;
using EdufyAPI.DTOs.ProgressDTOs;

namespace EdufyAPI.DTOs
{
    public class CourseReadDTO
    {
        public string Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;

        public string InstructorID { get; set; }
        public ICollection<LessonReadDTO> Lessons { get; set; }
        public ICollection<ProgressReadDTO> progresses { get; set; }

        // Add number of students enrolled here
    }
}
