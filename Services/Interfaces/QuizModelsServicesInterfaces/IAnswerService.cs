using EdufyAPI.DTOs.QuizModelsDTOs.AnswerDTOs;
using EdufyAPI.Models.QuizModels;

namespace EdufyAPI.Services.Interfaces.QuizModelsServicesInterfaces
{
    public interface IAnswerService
    {
        Task<bool> AddAnswerAsync(AnswerCreateDTO answer);
        Task<bool> UpdateAnswerAsync(Answer answer);
        Task<bool> DeleteAnswerAsync(string id);
        Task<Answer?> GetAnswerByIdAsync(string id);
        Task<IEnumerable<Answer>> GetAnswersByQuestionIdAsync(string questionId);
        Task<IEnumerable<Answer>> GetAnswersByQuizIdAsync(string quizId);
        Task<IEnumerable<Answer>> GetAnswersByUserIdAsync(string userId);
        Task<IEnumerable<Answer>> GetAnswersByUserIdAsync(string userId, string quizId);

    }
}
