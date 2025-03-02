namespace EdufyAPI.DTOs.ProgressDTOs
{
    public class ProgressCreateDTO
    {
        public string CourseId { get; set; }

        //public string EnrollmentId { get; set; }
        public string StudentId { get; set; }
        public int TotalLessonsCompleted { get; set; }
    }
}
