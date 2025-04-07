namespace EdufyAPI.DTOs.QuizModelsDTOs.AnswerDTOs
{
    public class AnswerUpdateDTO
    {
        public string Id { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public string QuestionId { get; set; } = string.Empty;
        public string SelectedOptionId { get; set; } = string.Empty;
    }
}
