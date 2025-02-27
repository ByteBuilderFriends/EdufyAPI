using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models
{
    /// Represents an individual lesson within a course.
    public class Lesson
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// The title of the lesson.
        [Required]
        public string Title { get; set; } = string.Empty;

        /// The content of the lesson.
        public string? Content { get; set; } = string.Empty;
        public string? ThumbnailUrl { get; set; } = string.Empty;
        public string? VideoUrl { get; set; } = string.Empty;
        public string? ExternalVideoUrl { get; set; } = string.Empty;   // Link from internet

        //new
        //public bool IsActive { get; set; } = true;
        //public bool IsDeleted { get; set; } = false;


        #region Relationships
        /// Foreign key reference to the course this lesson belongs to.
        [ForeignKey("Course")]
        public string CourseId { get; set; }
        public virtual Course Course { get; set; }

        /// The quiz associated with this lesson.
        public virtual Quiz? Quiz { get; set; }
        #endregion
    }
}