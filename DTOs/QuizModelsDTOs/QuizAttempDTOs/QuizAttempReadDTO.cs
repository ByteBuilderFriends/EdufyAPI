namespace EdufyAPI.DTOs.QuizModelsDTOs.QuizAttempDTOs
{
    public class QuizAttempReadDTO
    {
        public int Score { get; set; }

        public double ScorePercentage { get; set; }

        public bool IsPassed { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
