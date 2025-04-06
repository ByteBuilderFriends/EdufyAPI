using EdufyAPI.DTOs.QuizModelsDTOs.QuizDTOs;
using EdufyAPI.Repository.Interfaces;
using EdufyAPI.Services.Interfaces.QuizModelsServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers.QuizControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizEvaluationController : ControllerBase
    {
        private readonly IQuizEvaluationService _evaluationService;
        private readonly IUnitOfWork _unitOfWork;

        public QuizEvaluationController(IQuizEvaluationService evaluationService, IUnitOfWork unitOfWork)
        {
            _evaluationService = evaluationService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("evaluate/{quizId}/student/{studentId}")]
        public async Task<IActionResult> EvaluateQuiz(string quizId, string studentId)
        {
            // 1. Evaluate the quiz
            QuizResultDTO result = await _evaluationService.EvaluateQuizAsync(quizId, studentId);

            // 2. Get the quiz
            var quiz = await _unitOfWork.QuizRepository.GetByIdAsync(quizId);
            if (quiz == null)
                return NotFound("Quiz not found.");

            // 3. Save evaluation to Quiz
            quiz.StudentQuizEvaluation = result.Score;
            quiz.StudentQuizResult = result.CorrectAnswers;
            await _unitOfWork.QuizRepository.UpdateAsync(quiz);

            // 4. Return result
            return Ok(result);
        }
    }
}
