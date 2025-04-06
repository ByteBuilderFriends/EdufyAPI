using EdufyAPI.DTOs.QuizModelsDTOs.OptionDTOs;
using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.DTOs.QuizModelsDTOs.QuestionDTOs
{
    public class QuestionBulkUpdateDTO
    {
        [Required]
        public string Id { get; set; }
        public string? QuestionText { get; set; }
        public int? Marks { get; set; }
        public List<OptionUpdateDTO>? Options { get; set; }
    }
}
