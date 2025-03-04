namespace EdufyAPI.DTOs.QuizModelsDTOs.AnswerDTOs
{
    public class StudentAnswerReadDTO
    {
        public string Id { get; set; }
        public string StudentId { get; set; }
        public string QuestionId { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime AnsweredAt { get; set; }
    }
}
