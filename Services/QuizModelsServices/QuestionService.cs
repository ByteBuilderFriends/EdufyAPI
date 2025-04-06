using AutoMapper;
using EdufyAPI.DTOs.QuizModelsDTOs.QuestionDTOs;
using EdufyAPI.Models.QuizModels;
using EdufyAPI.Repository.Interfaces;
using EdufyAPI.Services.Interfaces.QuizModelsServicesInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EdufyAPI.Services.QuizModelsServices
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionReadDTO>> GetAllQuestionsAsync()
        {
            var questions = await _unitOfWork.QuestionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<QuestionReadDTO>>(questions ?? new List<Question>());
        }

        public async Task<QuestionReadDTO?> GetQuestionByIdAsync(string id)
        {
            var question = await _unitOfWork.QuestionRepository.GetByIdAsync(id);
            return question == null ? null : _mapper.Map<QuestionReadDTO>(question);
        }

        public async Task<QuestionReadDTO> CreateQuestionAsync(QuestionCreateDTO dto)
        {
            var question = _mapper.Map<Question>(dto);
            await _unitOfWork.QuestionRepository.AddAsync(question);
            return _mapper.Map<QuestionReadDTO>(question);
        }

        public async Task<bool> UpdateQuestionAsync(string id, QuestionUpdateDTO dto)
        {
            var existing = await _unitOfWork.QuestionRepository.GetByIdAsync(id);
            if (existing == null) return false;

            _mapper.Map(dto, existing);
            await _unitOfWork.QuestionRepository.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteQuestionAsync(string id)
        {
            var question = await _unitOfWork.QuestionRepository.GetByIdAsync(id);
            if (question == null) return false;

            await _unitOfWork.QuestionRepository.DeleteAsync(question);
            return true;
        }

        public async Task<IEnumerable<QuestionReadDTO>> GetQuizQuestionsAsync(string quizId)
        {
            var questions = await _unitOfWork.QuestionRepository.GetByCondition(q => q.QuizId == quizId);
            return _mapper.Map<IEnumerable<QuestionReadDTO>>(questions);
        }

        public async Task<IEnumerable<QuestionReadDTO>> SearchQuestionsAsync(string quizId, string text, bool isCaseSensitive)
        {
            if (isCaseSensitive)
            {
                var result = await _unitOfWork.QuestionRepository.GetByCondition(q =>
                    q.QuizId == quizId && EF.Functions.Collate(q.QuestionText, "SQL_Latin1_General_CP1_CS_AS").Contains(text));
                return _mapper.Map<IEnumerable<QuestionReadDTO>>(result);
            }
            else
            {
                var result = await _unitOfWork.QuestionRepository.GetByCondition(q =>
                    q.QuizId == quizId && q.QuestionText.Contains(text));
                return _mapper.Map<IEnumerable<QuestionReadDTO>>(result);
            }
        }

        public async Task<IEnumerable<QuestionReadDTO>> FilterQuestionsAsync(string quizId, string? text, bool isCaseSensitive, int? minPoints, int? maxPoints)
        {
            Expression<Func<Question, bool>> filter = q =>
                (string.IsNullOrWhiteSpace(text) ||
                    (isCaseSensitive
                        ? EF.Functions.Collate(q.QuestionText, "SQL_Latin1_General_CP1_CS_AS").Contains(text)
                        : q.QuestionText.Contains(text))) &&
                (!minPoints.HasValue || q.Marks >= minPoints.Value) &&
                (!maxPoints.HasValue || q.Marks <= maxPoints.Value) &&
                (string.IsNullOrEmpty(quizId) || q.QuizId == quizId);

            var questions = await _unitOfWork.QuestionRepository.GetByCondition(filter);
            return _mapper.Map<IEnumerable<QuestionReadDTO>>(questions);
        }

        public async Task<IEnumerable<QuestionReadDTO>> BulkCreateQuestionsAsync(List<QuestionCreateDTO> questionDTOs)
        {
            var questions = _mapper.Map<List<Question>>(questionDTOs);
            await _unitOfWork.QuestionRepository.AddRangeAsync(questions);
            return _mapper.Map<List<QuestionReadDTO>>(questions);
        }

        public async Task<IEnumerable<QuestionReadDTO>> BulkUpdateQuestionsAsync(List<QuestionBulkUpdateDTO> questionDTOs)
        {
            var ids = questionDTOs.Select(q => q.Id).ToList();
            var existingQuestions = await _unitOfWork.QuestionRepository.GetByCondition(q => ids.Contains(q.Id));

            foreach (var dto in questionDTOs)
            {
                var question = existingQuestions.FirstOrDefault(q => q.Id == dto.Id);
                if (question != null)
                {
                    _mapper.Map(dto, question);
                }
            }

            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<IEnumerable<QuestionReadDTO>>(existingQuestions);
        }

        public async Task<bool> BulkDeleteQuestionsAsync(List<string> questionIds)
        {
            var questions = await _unitOfWork.QuestionRepository.GetByCondition(q => questionIds.Contains(q.Id));
            if (!questions.Any()) return false;
            _unitOfWork.QuestionRepository.RemoveRange(questions);
            return true;
        }
    }
}

