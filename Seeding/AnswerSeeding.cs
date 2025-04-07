using EdufyAPI.Models.QuizModels;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.Seeding
{
    public class AnswerSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().HasData
            (
                   new
                   {
                       StudentId = "626b8c7f-f4d4-4467-bb37-570f1aa6fd77",
                       QuestionId = "QUESTION-1",
                       SelectedOptionId = "OPTION-2"
                   },
                    new
                    {
                        StudentId = "626b8c7f-f4d4-4467-bb37-570f1aa6fd77",
                        QuestionId = "QUESTION-2",
                        SelectedOptionId = "OPTION-1"
                    }
            );
        }
    }
}
