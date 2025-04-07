using AutoMapper;
using EdufyAPI.DTOs.QuizModelsDTOs.QuizDTOs;
using EdufyAPI.Models.QuizModels;
using EdufyAPI.Repository.Interfaces;
using EdufyAPI.Services.Interfaces.QuizModelsServicesInterfaces;

namespace EdufyAPI.Services.QuizModelsServices
{
    public class QuizService : IQuizService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuizService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuizReadDTO>> GetAllQuizzesAsync()
        {
            var quizzes = await _unitOfWork.QuizRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<QuizReadDTO>>(quizzes);
        }

        public async Task<QuizReadDTO> GetQuizByIdAsync(string id)
        {
            var quiz = await _unitOfWork.QuizRepository.GetByIdAsync(id);
            return quiz == null ? null : _mapper.Map<QuizReadDTO>(quiz);
        }

        public async Task<QuizReadDTO> CreateQuizAsync(QuizCreateDTO dto)
        {
            var quiz = _mapper.Map<Quiz>(dto);
            await _unitOfWork.QuizRepository.AddAsync(quiz);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<QuizReadDTO>(quiz);
        }

        public async Task<QuizReadDTO> UpdateQuizAsync(string id, QuizUpdateDTO dto)
        {
            var quiz = await _unitOfWork.QuizRepository.GetByIdAsync(id);
            if (quiz == null)
                throw new KeyNotFoundException("Quiz not found.");

            _mapper.Map(dto, quiz); // maps the updated fields to the existing quiz
            await _unitOfWork.QuizRepository.UpdateAsync(quiz);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<QuizReadDTO>(quiz); // return the updated data
        }

        public async Task<bool> DeleteQuizAsync(string id)
        {
            var quiz = await _unitOfWork.QuizRepository.GetByIdAsync(id);
            if (quiz == null) return false;

            _unitOfWork.QuizRepository.DeleteAsync(quiz);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }

}
