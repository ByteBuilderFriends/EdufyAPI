using EdufyAPI.DTOs.QuizModelsDTOs.QuizDTOs;

namespace EdufyAPI.Services.Interfaces.QuizModelsServicesInterfaces
{
    public interface IQuizEvaluationService
    {
        Task<bool> IsAnswerCorrectAsync(string selectedOptionId, string questionId);
        Task<int> GetMarksForQuizAsync(string quizId);

        Task<QuizResultDTO> EvaluateQuizAsync(string quizId, string studentId);

    }
}
