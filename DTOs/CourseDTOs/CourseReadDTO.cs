namespace EdufyAPI.DTOs
{
    public class CourseReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string InstructorName { get; set; } = "Unknown";

        // Add number of students enrolled here
    }
}
