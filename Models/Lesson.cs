using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models
{
    /// <summary>
    /// Represents an individual lesson within a course.
    /// </summary>
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The title of the lesson.
        /// </summary>
        [Required]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// The content of the lesson.
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// Foreign key reference to the course this lesson belongs to.
        /// </summary>
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        /// <summary>
        /// The quiz associated with this lesson.
        /// </summary>
        public virtual Quiz? Quiz { get; set; }
    }
}
