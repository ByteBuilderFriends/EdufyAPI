using EdufyAPI.Models.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models
{
    /// <summary>
    /// Tracks a student's progress in a course.
    /// </summary>
    public class Progress
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        /// <summary>
        /// The current lesson the student is working on.
        /// </summary>
        [ForeignKey("Lesson")]
        public int CurrentLessonId { get; set; }
        public virtual Lesson CurrentLesson { get; set; }

        /// <summary>
        /// The total number of lessons completed in the course.
        /// </summary>
        public int TotalLessonsCompleted { get; set; } = 0;

        /// <summary>
        /// The list of quiz results related to this course progress.
        /// </summary>
        public virtual List<QuizResult> QuizResults { get; set; } = new List<QuizResult>();

        /// <summary>
        /// Calculates the student's average quiz score in this course.
        /// </summary>
        public double AverageScore => QuizResults.Any() ? QuizResults.Average(q => q.Score) : 0;

        /// <summary>
        /// Returns the percentage of lessons completed in the course.
        /// </summary>
        public double LessonCompletionRate
        {
            get
            {
                var totalLessons = Course.Lessons.Count;
                return totalLessons > 0 ? (double)TotalLessonsCompleted / totalLessons * 100 : 0;
            }
        }

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
