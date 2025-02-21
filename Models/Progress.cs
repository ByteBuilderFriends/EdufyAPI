using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models
{
    /// Tracks a student's progress in a course.
    public class Progress
    {
        public int Id { get; set; }

        /// The total number of lessons completed in the course.
        public int TotalLessonsCompleted { get; set; } = 0;

        /// Calculates the student's average quiz score in this course.
        public double AverageScore => QuizResults.Any() ? QuizResults.Average(q => q.Score) : 0;

        /// Returns the percentage of lessons completed in the course.
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public double LessonCompletionRate
        {
            get
            {
                var totalLessons = Course.Lessons.Count;
                return totalLessons > 0 ? (double)TotalLessonsCompleted / totalLessons * 100 : 0;
            }
        }


        #region Relationships
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        /// The list of quiz results related to this course progress.
        public virtual List<QuizResult> QuizResults { get; set; } = new List<QuizResult>();
        #endregion


    }
}