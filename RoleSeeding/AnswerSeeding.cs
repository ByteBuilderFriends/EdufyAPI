using EdufyAPI.Models.QuizModels;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.RoleSeeding
{
    public class AnswerSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var question1Id = "QUESTION-3001"; // Example Question IDs
            var question2Id = "QUESTION-3002"; // Example Question IDs
            var question3Id = "QUESTION-3003"; // Example Question IDs

            modelBuilder.Entity<Answer>().HasData(
                new Answer
                {
                    Id = "ANSWER-4001", // Stronger ID
                    Text = "Option A: Correct answer for question 1",
                    IsCorrect = true,
                    OrderIndex = 1,
                    QuestionId = question1Id // Link to question 1
                },
                new Answer
                {
                    Id = "ANSWER-4002", // Stronger ID
                    Text = "Option B: Incorrect answer for question 1",
                    IsCorrect = false,
                    OrderIndex = 2,
                    QuestionId = question1Id // Link to question 1
                },
                new Answer
                {
                    Id = "ANSWER-4003", // Stronger ID
                    Text = "Option A: Correct answer for question 2",
                    IsCorrect = true,
                    OrderIndex = 1,
                    QuestionId = question2Id // Link to question 2
                },
                new Answer
                {
                    Id = "ANSWER-4004", // Stronger ID
                    Text = "Option B: Incorrect answer for question 2",
                    IsCorrect = false,
                    OrderIndex = 2,
                    QuestionId = question2Id // Link to question 2
                },
                new Answer
                {
                    Id = "ANSWER-4005", // Stronger ID
                    Text = "Option A: Correct answer for question 3",
                    IsCorrect = true,
                    OrderIndex = 1,
                    QuestionId = question3Id // Link to question 3
                },
                new Answer
                {
                    Id = "ANSWER-4006", // Stronger ID
                    Text = "Option B: Incorrect answer for question 3",
                    IsCorrect = false,
                    OrderIndex = 2,
                    QuestionId = question3Id // Link to question 3
                }
            );
        }
    }
}
