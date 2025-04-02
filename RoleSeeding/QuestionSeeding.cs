using EdufyAPI.Models.QuizModels;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.RoleSeeding
{
    public class QuestionSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var quiz1Id = "QUIZ-2002"; // Example Quiz IDs
            var quiz2Id = "QUIZ-2003"; // Example Quiz IDs

            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = "QUESTION-3001", // Stronger ID
                    Text = "What is the capital of France?",
                    Explanation = "The capital of France is Paris.",
                    Points = 10,
                    Type = QuestionType.SingleChoice, // Example QuestionType
                    OrderIndex = 1,
                    Answer = "Paris", // Correct answer text
                    QuizId = quiz1Id // Link to quiz 1
                },
                new Question
                {
                    Id = "QUESTION-3002", // Stronger ID
                    Text = "What is 2 + 2?",
                    Explanation = "2 + 2 equals 4.",
                    Points = 5,
                    Type = QuestionType.SingleChoice, // Example QuestionType
                    OrderIndex = 2,
                    Answer = "4", // Correct answer text
                    QuizId = quiz1Id // Link to quiz 1
                },
                new Question
                {
                    Id = "QUESTION-3003", // Stronger ID
                    Text = "Who is the author of '1984'?",
                    Explanation = "The author of '1984' is George Orwell.",
                    Points = 10,
                    Type = QuestionType.SingleChoice, // Example QuestionType
                    OrderIndex = 1,
                    Answer = "George Orwell", // Correct answer text
                    QuizId = quiz2Id // Link to quiz 2
                },
                new Question
                {
                    Id = "QUESTION-3004", // Stronger ID
                    Text = "What is the largest ocean on Earth?",
                    Explanation = "The largest ocean on Earth is the Pacific Ocean.",
                    Points = 5,
                    Type = QuestionType.SingleChoice, // Example QuestionType
                    OrderIndex = 2,
                    Answer = "Pacific Ocean", // Correct answer text
                    QuizId = quiz2Id // Link to quiz 2
                }
            );
        }
    }
}
