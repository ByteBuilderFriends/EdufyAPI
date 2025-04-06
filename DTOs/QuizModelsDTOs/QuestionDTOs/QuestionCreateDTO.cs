using EdufyAPI.DTOs.QuizModelsDTOs.OptionDTOs;
using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.DTOs.QuizModelsDTOs.QuestionDTOs
{
    public class QuestionCreateDTO
    {
        [Required]
        public string QuestionText { get; set; }
        [Required]
        public int Marks { get; set; }
        [Required]
        public string QuizId { get; set; }
        [Required]
        public List<OptionCreateDTO> Options { get; set; }
    }
}
