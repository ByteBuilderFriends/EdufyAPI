namespace EdufyAPI.DTOs.StudentDTOs
{
    public class StudentReadDTO
    {
        public string Id { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;

        public int NumberOfCompletedCourses { get; set; } = 0;

    }
}
