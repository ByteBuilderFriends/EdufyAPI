using EdufyAPI.Seeding;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.RoleSeeding
{
    public class RolesSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Apply role and user seeding
            IdentitySeeding.Seed(modelBuilder);

            // Seed Courses
            CourseSeeding.Seed(modelBuilder);

            // Seed Enrollments
            EnrollmentSeeding.Seed(modelBuilder);

            // Seed Progresses
            ProgressSeeding.Seed(modelBuilder);

            // Seed Lessons
            LessonSeeding.Seed(modelBuilder);

            // Seed Quizzes
            QuizSeeding.Seed(modelBuilder);

            // Seed Questions
            QuestionSeeding.Seed(modelBuilder);

            // Seed Options
            OptionSeeding.Seed(modelBuilder);

            // Seed Answers
            AnswerSeeding.Seed(modelBuilder);

        }
    }
}
