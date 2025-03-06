using EdufyAPI.Models.QuizModels;

namespace EdufyAPI.Helpers
{
    public class ScoeCalculationHelper
    {
        public double CalculateScore(Question question, List<string> studentAnswers)
        {
            switch (question.Type)
            {
                case QuestionType.SingleChoice:
                case QuestionType.TrueFalse:
                    return StandardScoring(question, studentAnswers);
                case QuestionType.MultipleChoice:
                    return MultipleChoiceScoring(question, studentAnswers);
                default:
                    return 0;
            }
        }

        private double StandardScoring(Question question, List<string> studentAnswers)
        {
            var correctAnswer = question.Answers.FirstOrDefault(a => a.IsCorrect);
            if (correctAnswer != null && studentAnswers.Count == 1 && studentAnswers.Contains(correctAnswer.Id))
            {
                return question.Points;
            }
            return 0;
        }

        private double MultipleChoiceScoring(Question question, List<string> studentAnswers)
        {
            var correctAnswers = question.Answers.Where(a => a.IsCorrect).Select(a => a.Id).ToList();
            var incorrectAnswers = question.Answers.Where(a => !a.IsCorrect).Select(a => a.Id).ToList();

            int correctSelected = studentAnswers.Count(a => correctAnswers.Contains(a));
            int incorrectSelected = studentAnswers.Count(a => incorrectAnswers.Contains(a));

            double correctRatio = (double)correctSelected / correctAnswers.Count;
            double incorrectPenalty = (double)incorrectSelected / question.Answers.Count;

            double finalScore = Math.Max(0, (correctRatio - incorrectPenalty)) * question.Points;

            return finalScore;
        }
    }
}
