using EdufyAPI.Models.QuizModels;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.RoleSeeding
{
    public class QuizAttempSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var progress1Id = "PROG-1001"; // Example Progress IDs
            var progress2Id = "PROG-1002"; // Example Progress IDs

            var quiz1Id = "QUIZ-2001"; // Example Quiz IDs
            var quiz2Id = "QUIZ-2002"; // Example Quiz IDs

            var student1Id = "e452e625-327a-4bf2-9540-3db6577ab68f"; // Example Student ID
            var student2Id = "626b8c7f-f4d4-4467-bb37-570f1aa6fd77"; // Example Student ID

            modelBuilder.Entity<QuizAttemp>().HasData(
                new QuizAttemp
                {
                    Id = "QUIZATTEMPT-10001", // Stronger ID
                    ProgressId = progress1Id, // Link to Progress 1
                    QuizId = quiz1Id, // Link to Quiz 1
                    StudentId = student1Id, // Link to Student 1
                    Score = 85, // Example score
                    StartedAt = DateTime.UtcNow.AddMinutes(-15), // Started 15 minutes ago
                    CompletedAt = DateTime.UtcNow, // Completed right now
                },
                new QuizAttemp
                {
                    Id = "QUIZATTEMPT-10002", // Stronger ID
                    ProgressId = progress2Id, // Link to Progress 2
                    QuizId = quiz2Id, // Link to Quiz 2
                    StudentId = student2Id, // Link to Student 2
                    Score = 60, // Example score
                    StartedAt = DateTime.UtcNow.AddMinutes(-20), // Started 20 minutes ago
                    CompletedAt = DateTime.UtcNow, // Completed right now
                },
                new QuizAttemp
                {
                    Id = "QUIZATTEMPT-10003", // Stronger ID
                    ProgressId = progress1Id, // Link to Progress 1
                    QuizId = quiz2Id, // Link to Quiz 2
                    StudentId = student1Id, // Link to Student 1
                    Score = 90, // Example score
                    StartedAt = DateTime.UtcNow.AddMinutes(-10), // Started 10 minutes ago
                    CompletedAt = DateTime.UtcNow, // Completed right now
                },
                new QuizAttemp
                {
                    Id = "QUIZATTEMPT-10004", // Stronger ID
                    ProgressId = progress2Id, // Link to Progress 2
                    QuizId = quiz1Id, // Link to Quiz 1
                    StudentId = student2Id, // Link to Student 2
                    Score = 75, // Example score
                    StartedAt = DateTime.UtcNow.AddMinutes(-25), // Started 25 minutes ago
                    CompletedAt = DateTime.UtcNow, // Completed right now
                }
            );
        }
    }
}
