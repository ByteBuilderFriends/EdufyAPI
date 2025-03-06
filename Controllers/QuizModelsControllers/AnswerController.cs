using AutoMapper;
using EdufyAPI.Helpers;
using EdufyAPI.Models.QuizModels;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static EdufyAPI.DTOs.QuizModelsDTOs.AnswerDTOs.AnswerDTO;

namespace EdufyAPI.Controllers.QuizModelsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ScoeCalculationHelper _scoreCalculationHelper;

        public AnswerController(IUnitOfWork unitOfWork, IMapper mapper, ScoeCalculationHelper scoreCalculationHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _scoreCalculationHelper = scoreCalculationHelper;
        }

        [HttpPost("submit")]
        public async Task<IActionResult> SubmitAnswers([FromBody] QuizSubmissionDto submission)
        {
            var quiz = await _unitOfWork.QuizRepository.GetByIdAsync(submission.QuizId);
            if (quiz == null)
                return BadRequest("Quiz not found.");

            var quizAttempt = new QuizAttemp
            {
                Id = Guid.NewGuid().ToString(),
                StudentId = submission.StudentId,
                QuizId = submission.QuizId,
                StartedAt = DateTime.UtcNow,
                ProgressId = submission.ProgressId
            };

            foreach (var questionSubmission in submission.Answers)
            {
                var question = await _unitOfWork.QuestionRepository.GetByIdAsync(questionSubmission.QuestionId);
                if (question == null)
                    return BadRequest($"Question {questionSubmission.QuestionId} not found.");

                double score = _scoreCalculationHelper.CalculateScore(question, questionSubmission.SelectedAnswers);
                quizAttempt.Score += score;

                quizAttempt.StudentAnswers.Add(new StudentAnswer
                {
                    Id = Guid.NewGuid().ToString(),
                    QuestionId = question.Id,
                    SelectedAnswerIds = questionSubmission.SelectedAnswers
                });
            }

            quizAttempt.CompletedAt = DateTime.UtcNow;

            await _unitOfWork.QuizAttempRepository.AddAsync(quizAttempt);
            await _unitOfWork.SaveChangesAsync();

            var attemptDto = _mapper.Map<QuizAttemptDTO>(quizAttempt);
            return Ok(new { message = "Quiz submitted successfully!", attempt = attemptDto });
        }
    }
}
