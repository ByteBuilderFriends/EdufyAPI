namespace EdufyAPI.DTOs.LessonDTOs
{
    public class LessonReadDTO
    {
        public string Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; }
        public string VideoUrl { get; set; }
        public string CourseId { get; set; }

    }
}
