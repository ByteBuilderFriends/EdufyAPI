using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models.Roles
{
    public class Student : User
    {
        // List of courses the student is enrolled in
        public virtual List<StudentCourse> EnrolledCourses { get; set; } = new List<StudentCourse>(); // Many-to-Many

        // List of progress records tracking student advancement in courses
        public virtual List<Progress> ProgressRecords { get; set; } = new List<Progress>();

        // List of quiz results showing past quiz performance
        public virtual List<QuizResult> QuizResults { get; set; } = new List<QuizResult>();

        // Auto-calculated property to get overall average score from all quizzes
        [NotMapped]
        public double AverageQuizScore => QuizResults.Any() ? QuizResults.Average(q => q.Score) : 0;
    }
}
