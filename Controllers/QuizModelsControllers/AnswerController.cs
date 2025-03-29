using AutoMapper;
using EdufyAPI.Helpers;
using EdufyAPI.Models.QuizModels;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static EdufyAPI.DTOs.QuizModelsDTOs.AnswerDTOs.AnswerDTO;

namespace EdufyAPI.Controllers.QuizModelsControllers
{
    /// <summary>
    /// Controller for managing quiz answers and submissions
    /// </summary>
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

        /// <summary>
        /// Submits answers for a quiz attempt
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Answer/submit
        ///     {
        ///         "quizId": "quiz123",
        ///         "studentId": "student456",
        ///         "progressId": "progress789",
        ///         "answers": [
        ///             {
        ///                 "questionId": "question1",
        ///                 "selectedAnswers": ["answerA", "answerB"]
        ///             },
        ///             {
        ///                 "questionId": "question2",
        ///                 "selectedAnswers": ["answerC"]
        ///             }
        ///         ]
        ///     }
        ///     
        /// </remarks>
        /// <param name="submission">Quiz submission data</param>
        /// <returns>Quiz attempt result with score</returns>
        /// <response code="200">Returns the quiz attempt details</response>
        /// <response code="400">Invalid quiz or question ID provided</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("submit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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