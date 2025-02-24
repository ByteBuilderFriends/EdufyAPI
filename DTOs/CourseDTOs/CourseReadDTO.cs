namespace EdufyAPI.DTOs
{
    public class CourseReadDTO
    {
        public string Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string InstructorID { get; set; }

        // Add number of students enrolled here
    }
}
