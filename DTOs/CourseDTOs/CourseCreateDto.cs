using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.DTOs.CourseDTOs
{
    public class CourseCreateDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public string InstructorId { get; set; } = string.Empty;
    }
}
