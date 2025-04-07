using EdufyAPI.DTOs.QuizModelsDTOs.OptionDTOs;

namespace EdufyAPI.Services.Interfaces.QuizModelsServicesInterfaces
{
    public interface IOptionService
    {
        Task<bool> CreateOptionAsync(string questionId, string optionText, bool isCorrect);
        Task<bool> UpdateOptionAsync(string id, OptionUpdateDTO optionUpdateDTO);
        Task<bool> DeleteOptionAsync(string optionId);
        Task<bool> DeleteOptionsByQuestionIdAsync(string questionId);
        Task<List<OptionReadDTO>> GetOptionsByQuestionIdAsync(string questionId);
        Task<OptionReadDTO?> GetOptionByIdAsync(string optionId);
    }
}
