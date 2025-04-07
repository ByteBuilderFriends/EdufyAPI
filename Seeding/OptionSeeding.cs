using EdufyAPI.Models.QuizModels;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.Seeding
{
    public class OptionSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Option>().HasData(
                new Option
                {
                    Id = "OPTION-1",
                    QuestionId = "QUESTION-1",
                    OptionText = "3",
                    IsCorrect = false
                },
                new Option
                {
                    Id = "OPTION-2",
                    QuestionId = "QUESTION-1",
                    OptionText = "4",
                    IsCorrect = true
                },
                new Option
                {
                    Id = "OPTION-3",
                    QuestionId = "QUESTION-1",
                    OptionText = "5",
                    IsCorrect = false
                },
                new Option
                {
                    Id = "OPTION-4",
                    QuestionId = "QUESTION-1",
                    OptionText = "6",
                    IsCorrect = false
                },
                new Option
                {
                    Id = "OPTION-5",
                    QuestionId = "QUESTION-2",
                    OptionText = "Berlin",
                    IsCorrect = false
                },
                new Option
                {
                    Id = "OPTION-6",
                    QuestionId = "QUESTION-2",
                    OptionText = "Madrid",
                    IsCorrect = false
                },
                new Option
                {
                    Id = "OPTION-7",
                    QuestionId = "QUESTION-2",
                    OptionText = "Paris",
                    IsCorrect = true
                },
                new Option
                {
                    Id = "OPTION-8",
                    QuestionId = "QUESTION-2",
                    OptionText = "Rome",
                    IsCorrect = false
                }
            );
        }
    }
}
