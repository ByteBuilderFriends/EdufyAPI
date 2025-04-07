using AutoMapper;
using EdufyAPI.DTOs.QuizModelsDTOs.OptionDTOs;
using EdufyAPI.Models.QuizModels;
using EdufyAPI.Repository.Interfaces;
using EdufyAPI.Services.Interfaces.QuizModelsServicesInterfaces;

namespace EdufyAPI.Services.QuizModelsServices
{
    public class OptionService : IOptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OptionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateOptionAsync(string questionId, string optionText, bool isCorrect)
        {
            // Check if question exists
            var question = await _unitOfWork.QuestionRepository.GetByIdAsync(questionId);
            if (question == null)
                throw new KeyNotFoundException($"Question with ID {questionId} not found.");

            try
            {
                var option = new Option
                {
                    QuestionId = questionId,
                    OptionText = optionText,
                    IsCorrect = isCorrect
                };
                await _unitOfWork.OptionRepository.AddAsync(option);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while creating the option: {ex.Message}");
            }

        }
        public async Task<bool> UpdateOptionAsync(string id, OptionUpdateDTO optionUpdateDTO)
        {
            var option = await _unitOfWork.OptionRepository.GetByIdAsync(id);
            if (option == null)
                throw new KeyNotFoundException($"Option with ID {id} not found.");
            try
            {
                _mapper.Map(optionUpdateDTO, option);
                await _unitOfWork.OptionRepository.UpdateAsync(option);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the option: {ex.Message}");
            }
        }
        public async Task<bool> DeleteOptionAsync(string optionId)
        {
            var option = await _unitOfWork.OptionRepository.GetByIdAsync(optionId);
            if (option == null)
                throw new KeyNotFoundException($"Option with ID {optionId} not found.");
            try
            {
                await _unitOfWork.OptionRepository.DeleteAsync(option);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the option: {ex.Message}");
            }
        }
        public async Task<bool> DeleteOptionsByQuestionIdAsync(string questionId)
        {
            var options = await _unitOfWork.OptionRepository.GetByCondition(o => o.QuestionId == questionId);
            if (options == null || !options.Any())
                throw new KeyNotFoundException($"No options found for question with ID {questionId}.");
            try
            {
                foreach (var option in options)
                {
                    await _unitOfWork.OptionRepository.DeleteAsync(option);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the options: {ex.Message}");
            }
        }
        public async Task<List<OptionReadDTO>> GetOptionsByQuestionIdAsync(string questionId)
        {
            var options = await _unitOfWork.OptionRepository.GetByCondition(o => o.QuestionId == questionId);
            if (options == null || !options.Any())
                return new List<OptionReadDTO>();
            try
            {
                var optionDTOs = _mapper.Map<List<OptionReadDTO>>(options);
                return optionDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the options: {ex.Message}");
            }
        }
        public async Task<OptionReadDTO?> GetOptionByIdAsync(string optionId)
        {
            var option = await _unitOfWork.OptionRepository.GetByIdAsync(optionId);
            if (option == null)
                throw new KeyNotFoundException($"Option with ID {optionId} not found.");
            try
            {
                var optionDTO = _mapper.Map<OptionReadDTO>(option);
                return optionDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the option: {ex.Message}");
            }
        }

    }

}
