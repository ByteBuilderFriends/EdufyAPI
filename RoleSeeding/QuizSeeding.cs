using EdufyAPI.Models.QuizModels;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.RoleSeeding
{
    public class QuizSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var lesson1Id = "LESSON-1001"; // Example Lesson IDs
            var lesson2Id = "LESSON-1002"; // Example Lesson IDs
            var lesson3Id = "LESSON-1003"; // Example Lesson IDs

            modelBuilder.Entity<Quiz>().HasData(
                new Quiz
                {
                    Id = "QUIZ-2001", // Stronger ID
                    Title = "Introduction to Programming Quiz",
                    Description = "This quiz tests your knowledge on basic programming concepts.",
                    PassingScore = 80,
                    TimeLimit = 300,
                    IsActive = true,
                    LessonId = lesson1Id // Linking to lesson 1
                },
                new Quiz
                {
                    Id = "QUIZ-2002", // Stronger ID
                    Title = "Variables and Data Types Quiz",
                    Description = "This quiz tests your understanding of variables and data types.",
                    PassingScore = 70,
                    TimeLimit = 300,
                    IsActive = true,
                    LessonId = lesson2Id // Linking to lesson 2
                },
                new Quiz
                {
                    Id = "QUIZ-2003", // Stronger ID
                    Title = "Advanced Algorithms Quiz",
                    Description = "This quiz evaluates your understanding of complex algorithms.",
                    PassingScore = 85,
                    TimeLimit = 300,
                    IsActive = true,
                    LessonId = lesson3Id // Linking to lesson 3
                }
            );
        }
    }
}
