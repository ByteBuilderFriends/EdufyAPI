using EdufyAPI.Models.QuizModels;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.Seeding
{
    public class QuizSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>().HasData(
                new Quiz
                {
                    Id = "QUIZ-1",
                    Title = "Math Quiz",
                    Description = "A quiz to test your math skills.",
                    TotalQuestions = 2,
                    TotalMarks = 100,
                    StudentQuizEvaluation = 0,
                    StudentQuizResult = 0,
                    LessonId = "LESSON-1001"
                },
                new Quiz
                {
                    Id = "QUIZ-2",
                    Title = "Science Quiz",
                    Description = "A quiz to test your science knowledge.",
                    TotalQuestions = 10,
                    TotalMarks = 100,
                    StudentQuizEvaluation = 0,
                    StudentQuizResult = 0,
                    LessonId = "LESSON-1002"
                }
            );
        }
    }
}
