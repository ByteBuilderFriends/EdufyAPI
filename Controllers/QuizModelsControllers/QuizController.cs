using EdufyAPI.DTOs.QuizModelsDTOs.QuizDTOs;
using EdufyAPI.Services.Interfaces.QuizModelsServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers.QuizModelsControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizReadDTO>>> GetAllQuizzes()
        {
            var quizzes = await _quizService.GetAllQuizzesAsync();
            return Ok(quizzes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuizReadDTO>> GetQuizById(string id)
        {
            var quiz = await _quizService.GetQuizByIdAsync(id);
            if (quiz == null) return NotFound();
            return Ok(quiz);
        }

        [HttpPost]
        public async Task<ActionResult<QuizReadDTO>> CreateQuiz(QuizCreateDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _quizService.CreateQuizAsync(dto);
            return CreatedAtAction(nameof(GetQuizById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuiz(string id, [FromForm] QuizUpdateDTO dto)
        {
            var updated = await _quizService.UpdateQuizAsync(id, dto);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(string id)
        {
            var deleted = await _quizService.DeleteQuizAsync(id);
            return deleted ? NoContent() : NotFound("Quiz not found.");
        }
    }
}