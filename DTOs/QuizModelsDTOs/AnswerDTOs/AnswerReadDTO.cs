namespace EdufyAPI.DTOs.QuizModelsDTOs.AnswerDTOs
{
    public class AnswerReadDTO
    {
        public string Id { get; set; }
        public int OrderIndex { get; set; }
        public string Text { get; set; }
        public string? Explanation { get; set; }
        public bool IsCorrect { get; set; }
    }
}
