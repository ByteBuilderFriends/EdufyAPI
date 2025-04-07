using EdufyAPI.Models.QuizModels;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.Seeding
{
    public class QuestionSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = "QUESTION-1",
                    QuizId = "QUIZ-1",
                    QuestionText = "What is 2 + 2?",
                    Marks = 5,

                },
                new Question
                {
                    Id = "QUESTION-2",
                    QuizId = "QUIZ-1",
                    QuestionText = "What is the capital of France?",
                    Marks = 95,

                }
            );
        }
    }
}
