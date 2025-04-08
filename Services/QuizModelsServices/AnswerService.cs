using AutoMapper;
using EdufyAPI.DTOs.QuizModelsDTOs.AnswerDTOs;
using EdufyAPI.Models.QuizModels;
using EdufyAPI.Repository.Interfaces;
using EdufyAPI.Services.Interfaces.QuizModelsServicesInterfaces;

namespace EdufyAPI.Services.QuizModelsServices
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AnswerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AnswerReadDTO>> GetAllAnswersAsync()
        {
            var answers = await _unitOfWork.AnswerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AnswerReadDTO>>(answers);
        }

        public async Task<AnswerReadDTO> GetAnswerByStudentAndQuestionAsync(string studentId, string questionId)
        {
            var answer = await _unitOfWork.AnswerRepository
                .GetSingleByCondition(a => a.StudentId == studentId && a.QuestionId == questionId);

            if (answer == null) return null;

            return _mapper.Map<AnswerReadDTO>(answer);
        }

        public async Task<AnswerReadDTO> CreateAnswerAsync(AnswerCreateDTO answerDTO)
        {
            var answer = _mapper.Map<Answer>(answerDTO);
            await _unitOfWork.AnswerRepository.AddAsync(answer);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<AnswerReadDTO>(answer);
        }

        public async Task<AnswerReadDTO> UpdateAnswerAsync(string studentId, string questionId, AnswerUpdateDTO updatedAnswerDTO)
        {
            var existingAnswer = await _unitOfWork.AnswerRepository
                .GetSingleByCondition(a => a.StudentId == studentId && a.QuestionId == questionId);
            if (existingAnswer == null) return null;

            // Check if the selected option exists and belongs to the correct question
            var selectedOption = await _unitOfWork.OptionRepository
                .GetSingleByCondition(o => o.Id == updatedAnswerDTO.SelectedOptionId);
            if (selectedOption == null || selectedOption.QuestionId != questionId) return null;

            _mapper.Map(updatedAnswerDTO, existingAnswer);

            await _unitOfWork.AnswerRepository.UpdateAsync(existingAnswer);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<AnswerReadDTO>(existingAnswer);
        }

        public async Task<bool> DeleteAnswerAsync(string studentId, string questionId)
        {
            var answer = await _unitOfWork.AnswerRepository
                .GetSingleByCondition(a => a.StudentId == studentId && a.QuestionId == questionId);

            if (answer == null) return false;

            await _unitOfWork.AnswerRepository.DeleteAsync(answer);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }

}
