using EdufyAPI.DTOs.QuizModelsDTOs.OptionDTOs;
using EdufyAPI.Services.Interfaces.QuizModelsServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers.QuizModelsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IOptionService _optionService;
        public OptionController(IOptionService optionService)
        {
            _optionService = optionService;
        }

        [HttpPost("{questionId}")]
        public async Task<IActionResult> CreateOption(string questionId, [FromBody] OptionCreateDTO optionCreateDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _optionService.CreateOptionAsync(questionId, optionCreateDTO.OptionText, optionCreateDTO.IsCorrect);
            return CreatedAtAction(nameof(GetOptionsByQuestionId), new { questionId }, created);
        }

        [HttpPut("{optionId}")]
        public async Task<IActionResult> UpdateOption(string optionId, [FromBody] OptionUpdateDTO optionUpdateDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updated = await _optionService.UpdateOptionAsync(optionId, optionUpdateDTO);
            return updated ? NoContent() : NotFound("Option not found.");
        }

        [HttpDelete("{optionId}")]
        public async Task<IActionResult> DeleteOption(string optionId)
        {
            var deleted = await _optionService.DeleteOptionAsync(optionId);
            return deleted ? NoContent() : NotFound("Option not found.");
        }

        [HttpGet("{questionId}")]
        public async Task<IActionResult> GetOptionsByQuestionId(string questionId)
        {
            var options = await _optionService.GetOptionsByQuestionIdAsync(questionId);
            return options == null ? NotFound("Options not found.") : Ok(options);
        }

        [HttpGet("option/{optionId}")]
        public async Task<IActionResult> GetOptionById(string optionId)
        {
            var option = await _optionService.GetOptionByIdAsync(optionId);
            return option == null ? NotFound("Option not found.") : Ok(option);
        }

        [HttpDelete("question/{questionId}")]
        public async Task<IActionResult> DeleteOptionsByQuestionId(string questionId)
        {
            var deleted = await _optionService.DeleteOptionsByQuestionIdAsync(questionId);
            return deleted ? NoContent() : NotFound("Options not found.");
        }
    }
}