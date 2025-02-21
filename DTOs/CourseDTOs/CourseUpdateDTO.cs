using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.DTOs.CourseDTOs
{
    public class CourseUpdateDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
