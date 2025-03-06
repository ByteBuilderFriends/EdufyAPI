namespace EdufyAPI.DTOs.QuizModelsDTOs.AnswerDTOs
{
    public class AnswerDTO
    {
        public class QuizAttemptDTO
        {
            public string Id { get; set; }
            public string StudentId { get; set; }
            public string QuizId { get; set; }
            public int Score { get; set; }
            public double ScorePercentage { get; set; }
            public bool IsPassed { get; set; }
            public DateTime StartedAt { get; set; }
            public DateTime? CompletedAt { get; set; }
            public TimeSpan Duration { get; set; }
            public List<StudentAnswerReadDTO> StudentAnswers { get; set; } = new();
        }

        public class QuizSubmissionDto
        {
            public string StudentId { get; set; }
            public string QuizId { get; set; }
            public string ProgressId { get; set; }
            public List<QuestionSubmissionDto> Answers { get; set; } = new();
        }

        public class QuestionSubmissionDto
        {
            public string QuestionId { get; set; }
            public List<string> SelectedAnswers { get; set; } = new();
        }
    }
}
