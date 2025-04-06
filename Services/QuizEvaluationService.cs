using EdufyAPI.DTOs.QuizDTOs;
using EdufyAPI.Repository.Interfaces;
using EdufyAPI.Services.Interfaces;

namespace EdufyAPI.Services
{
    public class QuizEvaluationService : IQuizEvaluationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuizEvaluationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> IsAnswerCorrectAsync(string selectedOptionId, string questionId)
        {
            var option = await _unitOfWork.OptionRepository.GetSingleByCondition(
                o => o.Id == selectedOptionId && o.QuestionId == questionId
            );

            return option?.IsCorrect ?? false;
        }

        public async Task<int> GetMarksForQuizAsync(string quizId)
        {
            try
            {
                var questions = await _unitOfWork.QuestionRepository.GetByCondition(q => q.QuizId == quizId);

                int totalMarks = 0;

                foreach (var question in questions)
                {
                    var correctOption = await _unitOfWork.OptionRepository.GetSingleByCondition(
                        o => o.QuestionId == question.Id && o.IsCorrect
                    );

                    if (correctOption != null)
                        totalMarks += question.Marks;
                }

                return totalMarks;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while calculating total marks.", ex);
            }
        }

        public async Task<QuizResultDTO> EvaluateQuizAsync(string quizId, string studentId)
        {
            try
            {
                var questions = await _unitOfWork.QuestionRepository.GetByCondition(q => q.QuizId == quizId);
                var questionIds = questions.Select(q => q.Id).ToList();

                var studentAnswers = await _unitOfWork.AnswerRepository.GetByCondition(
                    a => a.StudentId == studentId && questionIds.Contains(a.QuestionId)
                );

                int correctAnswersMarks = 0;

                foreach (var answer in studentAnswers)
                {
                    if (await IsAnswerCorrectAsync(answer.SelectedOptionId, answer.QuestionId))
                    {
                        var question = questions.FirstOrDefault(q => q.Id == answer.QuestionId);
                        if (question != null)
                        {
                            correctAnswersMarks += question.Marks;
                        }
                    }
                }

                var quiz = await _unitOfWork.QuizRepository.GetByIdAsync(quizId);

                var result = new QuizResultDTO
                {
                    TotalMarks = quiz.TotalMarks,
                    CorrectAnswers = correctAnswersMarks
                };

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while evaluating the quiz.", ex);
            }
        }
    }
}
