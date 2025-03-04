namespace EdufyAPI.DTOs.QuizModelsDTOs.AnswerDTOs
{
    // BUG: Thinking to remove the whole class, as we replaced it with Answer string
    public class AnswerReadDTO
    {
        public string Id { get; set; }
        public int OrderIndex { get; set; }
        public string Text { get; set; }
        public string? Explanation { get; set; }
        public bool IsCorrect { get; set; }
    }
}
