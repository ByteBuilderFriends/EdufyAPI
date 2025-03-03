using AutoMapper;
using EdufyAPI.DTOs.QuizModelsDTOs.QuestionDTOs;
using EdufyAPI.Models.QuizModels;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.Controllers.QuizModelsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Question
        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _unitOfWork.QuestionRepository.GetAllAsync();
            if (questions == null)
                return Ok(Enumerable.Empty<QuestionReadDTO>());
            var questionDTOs = _mapper.Map<IEnumerable<QuestionReadDTO>>(questions);
            return Ok(questionDTOs);
        }

        // GET: api/Question/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(string id)
        {
            var question = await _unitOfWork.QuestionRepository.GetByIdAsync(id);
            if (question == null)
                return NotFound("Question not found.");

            var questionDTO = _mapper.Map<QuestionReadDTO>(question);
            return Ok(questionDTO);
        }

        [HttpGet("{quizId}")]
        public async Task<IActionResult> GetQuizQuestions(string quizId)
        {
            var quiz = await _unitOfWork.QuizRepository.GetByIdAsync(quizId);

            if (quiz == null)
                return NotFound("Quiz not found.");

            var questions = quiz.Questions; // Lazy loading will fetch the questions

            var Questions = await _unitOfWork.QuestionRepository.GetByCondition(ques => ques.QuizId == quizId);
            if (!Questions.Any())
                return Ok(Enumerable.Empty<QuestionReadDTO>());

            var quizQuestionsDTO = _mapper.Map<QuestionReadDTO>(quiz);
            return Ok(quizQuestionsDTO);
        }

        // Search questions by text
        [HttpGet("search")]
        public async Task<IActionResult> SearchQuestions(string text, bool isCaseSensitive = false)
        {
            if (string.IsNullOrWhiteSpace(text))
                return BadRequest("Search text cannot be empty.");

            IReadOnlyList<Question> questions;
            if (isCaseSensitive)
            {
                // EF.Functions.Collate(expression, collation) is an Entity Framework Core function that changes the collation of a database column only for the current query.
                // Collation controls how text is compared and sorted in SQL Server.
                // SQL_Latin1_General_CP1_CS_AS → A case-sensitive collation (CS = Case-Sensitive).
                questions = await _unitOfWork.QuestionRepository.GetByCondition(q =>
                    EF.Functions.Collate(q.Text, "SQL_Latin1_General_CP1_CS_AS").Contains(text));
            }
            else
            {
                //By default, SQL Server collation is case-insensitive (CI), meaning "math" and "Math" are treated as the same.
                questions = await _unitOfWork.QuestionRepository.GetByCondition(q => q.Text.Contains(text));
            }

            var questionDTOs = _mapper.Map<IEnumerable<QuestionReadDTO>>(questions);
            return Ok(questionDTOs);
        }

        // Filter questions by type & points range
        //[HttpGet("filter")]
        //public async Task<IActionResult> FilterQuestions(
        //    [FromQuery] QuestionType? type,
        //    [FromQuery] int? minPoints,
        //    [FromQuery] int? maxPoints)
        //{
        //    var questions = await _unitOfWork.QuestionRepository.FilterQuestionsAsync(type, minPoints, maxPoints);
        //    var questionDTOs = _mapper.Map<IEnumerable<QuestionReadDTO>>(questions);

        //    return Ok(questionDTOs);
        //}



        // POST: api/Question
        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionCreateDTO questionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var question = _mapper.Map<Question>(questionDTO);
            await _unitOfWork.QuestionRepository.AddAsync(question);

            var createdQuestionDTO = _mapper.Map<QuestionReadDTO>(question);
            return CreatedAtAction(nameof(GetQuestionById), new { id = question.Id }, createdQuestionDTO);
        }

        // PUT: api/Question/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(string id, [FromBody] QuestionUpdateDTO questionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingQuestion = await _unitOfWork.QuestionRepository.GetByIdAsync(id);
            if (existingQuestion == null)
                return NotFound("Question not found.");

            _mapper.Map(questionDTO, existingQuestion);
            existingQuestion.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.QuestionRepository.UpdateAsync(existingQuestion);

            return NoContent();
        }

        // DELETE: api/Question/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(string id)
        {
            var question = await _unitOfWork.QuestionRepository.GetByIdAsync(id);
            if (question == null)
                return NotFound("Question not found.");

            await _unitOfWork.QuestionRepository.DeleteAsync(question);

            return NoContent();
        }
    }

}
