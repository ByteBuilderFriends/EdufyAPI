using EdufyAPI.DTOs.QuizModelsDTOs.AnswerDTOs;
using EdufyAPI.Services.Interfaces.QuizModelsServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers.QuizModelsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        // GET: api/answer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerReadDTO>>> GetAllAnswers()
        {
            var answers = await _answerService.GetAllAnswersAsync();
            return Ok(answers);
        }

        // GET: api/answer/{studentId}/{questionId}
        [HttpGet("{studentId}/{questionId}")]
        public async Task<ActionResult<AnswerReadDTO>> GetAnswer(string studentId, string questionId)
        {
            var answer = await _answerService.GetAnswerByStudentAndQuestionAsync(studentId, questionId);
            if (answer == null)
            {
                return NotFound();
            }
            return Ok(answer);
        }

        // POST: api/answer
        [HttpPost]
        public async Task<ActionResult<AnswerReadDTO>> CreateAnswer([FromBody] AnswerCreateDTO answerDTO)
        {
            var createdAnswer = await _answerService.CreateAnswerAsync(answerDTO);
            return CreatedAtAction(nameof(GetAnswer), new { studentId = createdAnswer.StudentId, questionId = createdAnswer.QuestionId }, createdAnswer);
        }

        // PUT: api/answer/{studentId}/{questionId}
        [HttpPut("{studentId}/{questionId}")]
        public async Task<ActionResult<AnswerReadDTO>> UpdateAnswer(string studentId, string questionId, [FromBody] AnswerUpdateDTO updatedAnswerDTO)
        {
            if (updatedAnswerDTO == null || string.IsNullOrEmpty(updatedAnswerDTO.SelectedOptionId))
            {
                return BadRequest("Invalid answer update data.");
            }
            var answer = await _answerService.UpdateAnswerAsync(studentId, questionId, updatedAnswerDTO);
            if (answer == null)
            {
                return NotFound();
            }
            return Ok(answer);
        }

        // DELETE: api/answer/{studentId}/{questionId}
        [HttpDelete("{studentId}/{questionId}")]
        public async Task<IActionResult> DeleteAnswer(string studentId, string questionId)
        {
            var result = await _answerService.DeleteAnswerAsync(studentId, questionId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
