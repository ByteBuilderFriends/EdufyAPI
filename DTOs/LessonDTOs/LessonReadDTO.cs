namespace EdufyAPI.DTOs.LessonDTOs
{
    public class LessonReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string CourseName { get; set; } = "Unknown";
    }
}
