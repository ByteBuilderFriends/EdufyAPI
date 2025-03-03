namespace EdufyAPI.DTOs.QuizModelsDTOs.QuizAttempDTOs
{
    public class QuizAttempCreateDTO
    {
        public int Score { get; set; }
        public double ScorePercentage { get; set; }
        public bool IsPassed { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string ProgressId { get; set; }

        public string QuizId { get; set; }

    }
}
