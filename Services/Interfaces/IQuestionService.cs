using EdufyAPI.DTOs.QuizModelsDTOs.QuestionDTOs;

namespace EdufyAPI.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionReadDTO>> GetAllQuestionsAsync();
        Task<QuestionReadDTO?> GetQuestionByIdAsync(string id);
        Task<QuestionReadDTO> CreateQuestionAsync(QuestionCreateDTO dto);
        Task<bool> UpdateQuestionAsync(string id, QuestionUpdateDTO dto);
        Task<bool> DeleteQuestionAsync(string id);
        Task<IEnumerable<QuestionReadDTO>> GetQuizQuestionsAsync(string quizId);
        Task<IEnumerable<QuestionReadDTO>> SearchQuestionsAsync(string quizId, string text, bool isCaseSensitive);
        Task<IEnumerable<QuestionReadDTO>> FilterQuestionsAsync(string quizId, string? text, bool isCaseSensitive, int? minPoints, int? maxPoints);
        Task<IEnumerable<QuestionReadDTO>> BulkCreateQuestionsAsync(List<QuestionCreateDTO> questionDTOs);
        Task<IEnumerable<QuestionReadDTO>> BulkUpdateQuestionsAsync(List<QuestionBulkUpdateDTO> questionDTOs);
        Task<bool> BulkDeleteQuestionsAsync(List<string> questionIds);
    }


}
