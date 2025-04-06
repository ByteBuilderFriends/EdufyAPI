using EdufyAPI.DTOs.QuizModelsDTOs.OptionDTOs;

namespace EdufyAPI.DTOs.QuizModelsDTOs.QuestionDTOs
{
    public class QuestionUpdateDTO
    {
        public string? QuestionText { get; set; }
        public int? Marks { get; set; }
        public List<OptionUpdateDTO>? Options { get; set; }
    }
}
