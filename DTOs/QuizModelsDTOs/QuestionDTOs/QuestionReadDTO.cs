using EdufyAPI.DTOs.QuizModelsDTOs.OptionDTOs;

namespace EdufyAPI.DTOs.QuizModelsDTOs.QuestionDTOs
{
    public class QuestionReadDTO
    {
        public string Id { get; set; }
        public string QuestionText { get; set; }
        public int Marks { get; set; }
        public string QuizId { get; set; }
        public List<OptionReadDTO> Options { get; set; }
    }
}
