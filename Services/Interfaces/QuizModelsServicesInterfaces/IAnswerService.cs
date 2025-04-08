using EdufyAPI.DTOs.QuizModelsDTOs.AnswerDTOs;

namespace EdufyAPI.Services.Interfaces.QuizModelsServicesInterfaces
{
    public interface IAnswerService
    {
        Task<AnswerReadDTO> GetAnswerByStudentAndQuestionAsync(string studentId, string questionId);
        Task<IEnumerable<AnswerReadDTO>> GetAllAnswersAsync();
        Task<AnswerReadDTO> CreateAnswerAsync(AnswerCreateDTO answer);
        Task<AnswerReadDTO> UpdateAnswerAsync(string studentId, string questionId, AnswerUpdateDTO updatedAnswer);
        Task<bool> DeleteAnswerAsync(string studentId, string questionId);

    }
}
