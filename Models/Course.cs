using EdufyAPI.Models.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models
{
    public class Course
    {
        public int Id { get; set; }

        /// The title of the course.
        [Required]
        public string Title { get; set; } = string.Empty;

        /// The description of the course content.
        public string Description { get; set; } = string.Empty;

        #region Relationships

        /// Collection of lessons in the course.
        public virtual List<Lesson> Lessons { get; set; } = new List<Lesson>();

        /// Tracks students' progress in the course.
        public virtual List<Progress> CourseProgress { get; set; } = new List<Progress>();

        // Foreign Key - Instructor

        [ForeignKey("Instructor")]
        public string InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }


        // Many-to-Many
        public virtual List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
        #endregion
    }
}