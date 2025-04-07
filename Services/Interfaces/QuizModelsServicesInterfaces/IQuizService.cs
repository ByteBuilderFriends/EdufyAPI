using EdufyAPI.DTOs.QuizModelsDTOs.QuizDTOs;

namespace EdufyAPI.Services.Interfaces.QuizModelsServicesInterfaces
{
    public interface IQuizService
    {
        Task<IEnumerable<QuizReadDTO>> GetAllQuizzesAsync();
        Task<QuizReadDTO?> GetQuizByIdAsync(string id);
        Task<QuizReadDTO> CreateQuizAsync(QuizCreateDTO dto);
        Task<QuizReadDTO> UpdateQuizAsync(string id, QuizUpdateDTO dto);
        Task<bool> DeleteQuizAsync(string id);
    }

}
