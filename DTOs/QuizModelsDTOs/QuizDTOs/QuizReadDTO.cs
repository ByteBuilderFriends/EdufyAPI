namespace EdufyAPI.DTOs.QuizModelsDTOs.QuizDTOs
{
    public class QuizReadDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int PassingScore { get; set; }
        public int TimeLimit { get; set; }
        public bool IsActive { get; set; }
        public int TotalQuestions { get; set; }
        public int TotalPoints { get; set; }
        public string LessonId { get; set; }
    }

}
