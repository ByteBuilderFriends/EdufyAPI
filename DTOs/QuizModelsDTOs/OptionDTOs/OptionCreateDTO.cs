using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.DTOs.QuizModelsDTOs.OptionDTOs
{
    public class OptionCreateDTO
    {
        [Required]
        public string OptionText { get; set; }
        [Required]
        public bool IsCorrect { get; set; }
    }
}
