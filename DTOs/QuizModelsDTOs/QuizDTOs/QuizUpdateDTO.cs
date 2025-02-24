using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.DTOs.QuizModelsDTOs.QuizDTOs
{
    public class QuizUpdateDTO
    {
        [Required]
        [MaxLength(100)]
        public string InternalTitle { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Range(0, 100)]
        public int PassingScore { get; set; } = 50;

        [Range(0, 300)]
        public int TimeLimit { get; set; } = 0;

        public bool IsActive { get; set; } = true;
    }

}
