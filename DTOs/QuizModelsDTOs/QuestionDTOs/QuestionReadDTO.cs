using EdufyAPI.DTOs.QuizModelsDTOs.AnswerDTOs;

namespace EdufyAPI.DTOs.QuizModelsDTOs.QuestionDTOs
{
    public class QuestionReadDTO
    {
        public string Id { get; set; }
        public int OrderIndex { get; set; }
        public int Points { get; set; }
        public QuestionType Type { get; set; }
        public string Text { get; set; }
        public string? Explanation { get; set; }
        public string QuizId { get; set; }
        public string QuizName { get; set; } = string.Empty; // Nested property
        public List<AnswerReadDTO> Answers { get; set; }
    }
}
