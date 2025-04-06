using EdufyAPI.DTOs.QuizModelsDTOs.QuestionDTOs;
using EdufyAPI.Services.Interfaces.QuizModelsServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers.QuizModelsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions() => Ok(await _questionService.GetAllQuestionsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(string id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);
            return question == null ? NotFound("Question not found.") : Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionCreateDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _questionService.CreateQuestionAsync(dto);
            return CreatedAtAction(nameof(GetQuestionById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(string id, [FromBody] QuestionUpdateDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updated = await _questionService.UpdateQuestionAsync(id, dto);
            return updated ? NoContent() : NotFound("Question not found.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(string id)
        {
            var deleted = await _questionService.DeleteQuestionAsync(id);
            return deleted ? NoContent() : NotFound("Question not found.");
        }

        [HttpGet("quiz/{quizId}")]
        public async Task<IActionResult> GetQuizQuestions(string quizId)
            => Ok(await _questionService.GetQuizQuestionsAsync(quizId));

        [HttpGet("search")]
        public async Task<IActionResult> SearchQuestions(string quizId, string text, bool isCaseSensitive = false)
        {
            if (string.IsNullOrWhiteSpace(text)) return BadRequest("Search text cannot be empty.");
            return Ok(await _questionService.SearchQuestionsAsync(quizId, text, isCaseSensitive));
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterQuestions(string quizId, string? text = null, bool isCaseSensitive = false, int? minPoints = null, int? maxPoints = null)
            => Ok(await _questionService.FilterQuestionsAsync(quizId, text, isCaseSensitive, minPoints, maxPoints));

        [HttpPost("bulk-create")]
        public async Task<IActionResult> BulkCreateQuestions([FromBody] List<QuestionCreateDTO> dtos)
        {
            if (dtos == null || dtos.Count == 0) return BadRequest("No questions provided.");
            var result = await _questionService.BulkCreateQuestionsAsync(dtos);
            return Ok(result);
        }

        [HttpPut("bulk-update")]
        public async Task<IActionResult> BulkUpdateQuestions([FromBody] List<QuestionBulkUpdateDTO> dtos)
        {
            if (dtos == null || dtos.Count == 0) return BadRequest("No questions provided.");
            var result = await _questionService.BulkUpdateQuestionsAsync(dtos);
            return Ok(result);
        }

        [HttpDelete("bulk-delete")]
        public async Task<IActionResult> BulkDeleteQuestions([FromBody] List<string> ids)
        {
            if (ids == null || ids.Count == 0) return BadRequest("No question IDs provided.");
            var deleted = await _questionService.BulkDeleteQuestionsAsync(ids);
            return deleted ? NoContent() : NotFound("No matching questions found.");
        }

    }
}