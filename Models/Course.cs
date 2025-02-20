using EdufyAPI.Models.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models
{
    /// <summary>
    /// Represents a course containing multiple lessons.
    /// </summary>
    public class Course
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The title of the course.
        /// </summary>
        [Required]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// The description of the course content.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Collection of lessons in the course.
        /// </summary>
        public virtual List<Lesson> Lessons { get; set; } = new List<Lesson>();

        /// <summary>
        /// Tracks students' progress in the course.
        /// </summary>
        public virtual List<Progress> CourseProgress { get; set; } = new List<Progress>();

        // Foreign Key - Instructor

        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }


        // Many-to-Many
        public virtual List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
