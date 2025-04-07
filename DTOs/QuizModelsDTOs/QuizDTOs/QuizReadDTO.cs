namespace EdufyAPI.DTOs.QuizModelsDTOs.QuizDTOs
{
    public class QuizReadDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TotalQuestions { get; set; }
        public int TotalMarks { get; set; }
        public int Duration { get; set; }
        public string LessonId { get; set; }
    }
}
