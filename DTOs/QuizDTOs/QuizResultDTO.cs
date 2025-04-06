namespace EdufyAPI.DTOs.QuizDTOs
{
    public class QuizResultDTO
    {
        public int TotalMarks { get; set; }
        public int CorrectAnswers { get; set; }
        public int Score => TotalMarks == 0 ? 0 : (int)((double)CorrectAnswers / TotalMarks * 100);
    }
}
