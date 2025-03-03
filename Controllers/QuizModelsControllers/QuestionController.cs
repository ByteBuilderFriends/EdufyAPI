using AutoMapper;
using EdufyAPI.DTOs.QuizModelsDTOs.QuestionDTOs;
using EdufyAPI.Models.QuizModels;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        #region Standard CRUD Operations
        // GET: GetQuestionById(string id)
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
        #endregion

        #region Additional Read Operations
        [HttpGet("quiz/{quizId}")]
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
                // EF.Functions.Collate(expression, collation) is an EF Core function that changes the collation of a database column only for the current query.
                // Collation controls how text is compared and sorted in SQL Server.
                // SQL_Latin1_General_CP1_CS_AS → A case-sensitive collation (CS = Case-Sensitive).
                // Show this https://youtu.be/AIbSuR0ndak?si=aUtnTinNgiYiClzq
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
        [HttpGet("filter")]
        public async Task<IActionResult> FilterQuestionsAsync(
             string? text = null,
             bool isCaseSensitive = false,
             QuestionType? type = null,
             int? minPoints = null,
             int? maxPoints = null,
             string? quizId = null)
        {
            // Build dynamic query with filters
            Expression<Func<Question, bool>> filter = q =>
                (string.IsNullOrWhiteSpace(text) ||
                 (isCaseSensitive
                    ? EF.Functions.Collate(q.Text, "SQL_Latin1_General_CP1_CS_AS").Contains(text)
                    : q.Text.Contains(text))) &&
                (!type.HasValue || q.Type == type.Value) &&
                (!minPoints.HasValue || q.Points >= minPoints.Value) &&
                (!maxPoints.HasValue || q.Points <= maxPoints.Value) &&
                (string.IsNullOrEmpty(quizId) || q.QuizId == quizId);

            var questions = await _unitOfWork.QuestionRepository.GetByCondition(filter);

            var questionDTOs = _mapper.Map<IEnumerable<QuestionReadDTO>>(questions);

            return Ok(questionDTOs);
        }

        #endregion

        #region Bulk Operations
        /// Bulk create multiple questions.
        [HttpPost("bulk-create")]
        public async Task<IActionResult> BulkCreateQuestions([FromBody] List<QuestionCreateDTO> questionDTOs)
        {
            if (questionDTOs == null || questionDTOs.Count == 0)
                return BadRequest("No questions provided for creation.");

            var questions = _mapper.Map<List<Question>>(questionDTOs);

            await _unitOfWork.QuestionRepository.AddRangeAsync(questions);

            var createdQuestionsDTOs = _mapper.Map<List<QuestionReadDTO>>(questions);
            return CreatedAtAction(nameof(BulkCreateQuestions), createdQuestionsDTOs);//??
        }

        /// Bulk delete multiple questions by IDs.
        [HttpDelete("bulk-delete")]
        public async Task<IActionResult> BulkDeleteQuestions([FromBody] List<string> questionIds)
        {
            if (questionIds == null || questionIds.Count == 0)
                return BadRequest("No question IDs provided for deletion.");

            var questions = await _unitOfWork.QuestionRepository.GetByCondition(q => questionIds.Contains(q.Id));

            if (questions == null || !questions.Any())
                return NotFound("No matching questions found.");

            _unitOfWork.QuestionRepository.RemoveRange(questions);

            return NoContent();
        }

        /// Bulk update multiple questions.
        [HttpPut("bulk-update")]
        public async Task<IActionResult> BulkUpdateQuestions([FromBody] List<QuestionBulkUpdateDTO> questionDTOs)
        {
            if (questionDTOs == null || questionDTOs.Count == 0)
                return BadRequest("No questions provided for update.");

            var questionIds = questionDTOs.Select(q => q.Id).ToList();
            var existingQuestions = await _unitOfWork.QuestionRepository.GetByCondition(q => questionIds.Contains(q.Id));

            if (existingQuestions == null || !existingQuestions.Any())
                return NotFound("No matching questions found.");

            foreach (var questionDTO in questionDTOs)
            {
                var question = existingQuestions.FirstOrDefault(q => q.Id == questionDTO.Id);
                if (question != null)
                {
                    _mapper.Map(questionDTO, question);
                    question.UpdatedAt = DateTime.UtcNow;
                }
            }

            await _unitOfWork.SaveChangesAsync();
            var updatedQuestionsDTOs = _mapper.Map<List<QuestionReadDTO>>(existingQuestions);

            return Ok(updatedQuestionsDTOs);
        }


        #endregion

        #region Statistical & Reporting Actions

        #endregion

        #region AI-Powered Enhancements

        #endregion

    }

}
