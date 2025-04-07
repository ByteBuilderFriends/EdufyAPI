using EdufyAPI.DTOs.QuizModelsDTOs.AnswerDTOs;
using EdufyAPI.Models.QuizModels;
using EdufyAPI.Repository.Interfaces;
using EdufyAPI.Services.Interfaces.QuizModelsServicesInterfaces;

namespace EdufyAPI.Services.QuizModelsServices
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnswerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<bool> AddAnswerAsync(AnswerCreateDTO answer)
        {
            if (answer == null)
                throw new ArgumentNullException(nameof(answer));

            var answerEntity = new Answer
            {
                StudentId = answer.StudentId,
                QuestionId = answer.QuestionId,
                SelectedOptionId = answer.SelectedOptionId
            };


            _unitOfWork.AnswerRepository.AddAsync(answerEntity);

            return Task.FromResult(true);
        }

        public Task<bool> DeleteAnswerAsync(string id)
        {
            var answer = _unitOfWork.AnswerRepository.GetByIdAsync(id);
            if (answer == null)
                throw new ArgumentNullException(nameof(answer));

            try
            {
                _unitOfWork.AnswerRepository.DeleteAsync(id);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex.Message);
                return Task.FromResult(false);
            }
        }

        public async Task<Answer?> GetAnswerByIdAsync(string id)
        {
            var answer = await _unitOfWork.AnswerRepository.GetByIdAsync(id);
            if (answer == null)
            {
                throw new KeyNotFoundException($"Answer with ID '{id}' not found.");
            }
            return answer;
        }


        public async Task<IEnumerable<Answer>> GetAnswersByQuestionIdAsync(string questionId)
        {
            var question = _unitOfWork.QuestionRepository.GetByIdAsync(questionId);
            if (question == null)
                throw new ArgumentNullException(nameof(question));

            var answers = await _unitOfWork.AnswerRepository.GetByCondition(a => a.QuestionId == questionId);
            if (answers == null)
                throw new ArgumentNullException(nameof(answers));

            return answers;
        }

        public async Task<IEnumerable<Answer>> GetAnswersByQuizIdAsync(string quizId)
        {
            var quiz = _unitOfWork.QuizRepository.GetByIdAsync(quizId);
            if (quiz == null)
                throw new ArgumentNullException(nameof(quiz));
            var answers = await _unitOfWork.AnswerRepository.GetByCondition(a => a.Question.QuizId == quizId);
            if (answers == null)
                throw new ArgumentNullException(nameof(answers));
            return answers;
        }

        public async Task<IEnumerable<Answer>> GetAnswersByUserIdAsync(string userId)
        {
            var student = await _unitOfWork.StudentRepository.GetByIdAsync(userId);
            if (student == null)
                throw new ArgumentNullException(nameof(student));
            var answers = await _unitOfWork.AnswerRepository.GetByCondition(a => a.StudentId == userId);
            if (answers == null)
                throw new ArgumentNullException(nameof(answers));
            return answers;
        }

        public async Task<IEnumerable<Answer>> GetAnswersByUserIdAsync(string userId, string quizId)
        {
            var student = await _unitOfWork.StudentRepository.GetByIdAsync(userId);
            var quiz = await _unitOfWork.QuizRepository.GetByIdAsync(quizId);

            if (student == null)
                throw new ArgumentNullException(nameof(student));

            if (quiz == null)
                throw new ArgumentNullException(nameof(quiz));

            var answers = await _unitOfWork.AnswerRepository.GetByCondition(a => a.StudentId == userId && a.Question.QuizId == quizId);
            if (answers == null)
                throw new ArgumentNullException(nameof(answers));

            return answers;
        }

        public Task<bool> UpdateAnswerAsync(Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
