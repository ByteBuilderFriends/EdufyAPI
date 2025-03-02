namespace EdufyAPI.DTOs.ProgressDTOs
{
    public class ProgressReadDTO
    {
        public string Id { get; set; }
        public int TotalLessonsCompleted { get; set; }
        ////public double AverageScore { get; set; }
        public double LessonCompletionRate { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCertified { get; set; }
        public string? CertificateNumber { get; set; }
        public string CourseId { get; set; }
    }
}
