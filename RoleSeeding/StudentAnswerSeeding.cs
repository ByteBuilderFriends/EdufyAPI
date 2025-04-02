using EdufyAPI.Models.QuizModels;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.RoleSeeding
{
    public class StudentAnswerSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var quizAttempt1Id = "QUIZATTEMPT-10001";
            var quizAttempt2Id = "QUIZATTEMPT-10002";

            var question1Id = "QUESTION-3001";

            var answer1Id = "ANSWER-4001";
            var answer2Id = "ANSWER-4002";

            var student1Id = "626b8c7f-f4d4-4467-bb37-570f1aa6fd77";
            var student2Id = "e452e625-327a-4bf2-9540-3db6577ab68f";

            modelBuilder.Entity<StudentAnswer>().HasData(
                new StudentAnswer
                {
                    Id = "STUDENTANSWER-7001",
                    QuizResultId = quizAttempt1Id,
                    QuestionId = question1Id,
                    AnswerId = answer1Id,
                    SubmittedAnswer = "Option A: Correct answer for question 1",
                    IsCorrect = true,
                    SubmittedAt = DateTime.UtcNow
                },
                new StudentAnswer
                {
                    Id = "STUDENTANSWER-7004",
                    QuizResultId = quizAttempt2Id,
                    QuestionId = question1Id,
                    AnswerId = answer2Id,
                    SubmittedAnswer = "Option B: Incorrect answer for question 1",
                    IsCorrect = false,
                    SubmittedAt = DateTime.UtcNow
                }
            );
        }

    }
}
