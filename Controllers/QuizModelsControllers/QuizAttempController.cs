using AutoMapper;
using EdufyAPI.DTOs.QuizModelsDTOs.QuizAttempDTOs;
using EdufyAPI.Models.QuizModels;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers.QuizModelsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizAttempController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuizAttempController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/QuizAttemp
        [HttpGet]
        public async Task<IActionResult> GetQuizAttemp()
        {
            var quizAttemps = await _unitOfWork.QuizAttempRepository.GetAllAsync();

            if (quizAttemps == null || !quizAttemps.Any())
                return NotFound("No quiz attempts found.");

            var quizAttempDTOs = _mapper.Map<IEnumerable<QuizAttempReadDTO>>(quizAttemps);
            return Ok(quizAttempDTOs);
        }

        // GET: api/QuizAttemp/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuizAttempById(string id)
        {
            var quizAttemp = await _unitOfWork.QuizAttempRepository.GetByIdAsync(id);
            if (quizAttemp == null)
                return NotFound("Quiz attempt not found.");
            var quizAttempDTO = _mapper.Map<QuizAttempReadDTO>(quizAttemp);
            return Ok(quizAttempDTO);
        }

        // POST: api/QuizAttemp
        [HttpPost]
        public async Task<IActionResult> CreateQuizAttemp([FromBody] QuizAttempCreateDTO quizAttempDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var quizAttemp = _mapper.Map<QuizAttemp>(quizAttempDTO);
            await _unitOfWork.QuizAttempRepository.AddAsync(quizAttemp);
            var createdQuizAttempDTO = _mapper.Map<QuizAttempReadDTO>(quizAttemp);
            return CreatedAtAction(nameof(GetQuizAttempById), new { id = quizAttemp.Id }, createdQuizAttempDTO);
        }

        // PUT: api/QuizAttemp/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuizAttemp(string id, [FromBody] QuizAttempReadDTO quizAttempDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var quizAttemp = await _unitOfWork.QuizAttempRepository.GetByIdAsync(id);
            if (quizAttemp == null)
                return NotFound("Quiz attempt not found.");
            _mapper.Map(quizAttempDTO, quizAttemp);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/QuizAttemp/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizAttemp(string id)
        {
            var quizAttemp = await _unitOfWork.QuizAttempRepository.GetByIdAsync(id);
            if (quizAttemp == null)
                return NotFound("Quiz attempt not found.");
            await _unitOfWork.QuizAttempRepository.DeleteAsync(quizAttemp);
            return NoContent();
        }

        // GET: api/QuizAttemp/GetQuizAttempByProgressId/{progressId}
        [HttpGet("GetQuizAttempByProgressId/{progressId}")]
        public async Task<IActionResult> GetQuizAttempByProgressId(string progressId)
        {
            var quizAttemp = await _unitOfWork.QuizAttempRepository.GetByCondition(q => q.ProgressId == progressId);
            if (quizAttemp == null)
                return NotFound("Quiz attempt not found.");
            var quizAttempDTO = _mapper.Map<QuizAttempReadDTO>(quizAttemp);
            return Ok(quizAttempDTO);
        }


        // NOTE: Here we need to return a List of QuizAttempReadDTOs, so i need to update the relationship in the QuizAttemp model
        // GET: api/QuizAttemp/GetQuizAttempByQuizId/{quizId}
        // GET: api/QuizAttemp/ByQuiz/{quizId}
        [HttpGet("ByQuiz/{quizId}")]
        public async Task<IActionResult> GetQuizAttemptsByQuiz(string quizId)
        {
            var attempts = await _unitOfWork.QuizAttempRepository.GetByCondition(q => q.QuizId == quizId);
            if (!attempts.Any())
                return NotFound("No attempts found for this quiz.");

            var attemptDTOs = _mapper.Map<IReadOnlyList<QuizAttempReadDTO>>(attempts);
            return Ok(attemptDTOs);
        }


        // GET: api/QuizAttemp/GetQuizAttempByStudentId/{studentId}
        [HttpGet("GetQuizAttempByStudentId/{studentId}")]
        public async Task<IActionResult> GetQuizAttemptsByStudent(string studentId)
        {
            var attempts = await _unitOfWork.QuizAttempRepository.GetByCondition(q => q.Progress.StudentId == studentId);
            if (!attempts.Any())
                return NotFound("No quiz attempts found for this student.");

            var attemptDTOs = _mapper.Map<IReadOnlyList<QuizAttempReadDTO>>(attempts);
            return Ok(attemptDTOs);
        }


        // GET: api/QuizAttemp/BestScore/{studentId}/{quizId}
        [HttpGet("BestScore/{studentId}/{quizId}")]
        public async Task<IActionResult> GetStudentBestScore(string studentId, string quizId)
        {
            var quizAttempts = await _unitOfWork.QuizAttempRepository
            .GetByCondition(q => q.Progress.StudentId == studentId && q.QuizId == quizId);

            if (quizAttempts == null || !quizAttempts.Any())
                return NotFound("No attempts found for this student in the specified quiz.");

            var bestAttempt = quizAttempts
                .OrderByDescending(q => q.Score)
                .FirstOrDefault();

            return Ok(new { bestAttempt.Score, bestAttempt.ScorePercentage, bestAttempt.IsPassed });
        }

        // GET: api/QuizAttemp/Duration/{attemptId}
        [HttpGet("Duration/{attemptId}")]
        public async Task<IActionResult> GetQuizAttemptDuration(string attemptId)
        {
            var attempt = await _unitOfWork.QuizAttempRepository.GetByIdAsync(attemptId);
            if (attempt == null)
                return NotFound("Quiz attempt not found.");

            return Ok(new { attempt.Duration });
        }


        // GET: api/QuizAttemp/PassFailStats/{quizId}
        [HttpGet("PassFailStats/{quizId}")]
        public async Task<IActionResult> GetPassFailStats(string quizId)
        {
            var attempts = await _unitOfWork.QuizAttempRepository.GetByCondition(q => q.QuizId == quizId);

            if (!attempts.Any())
                return NotFound("No attempts found for this quiz.");

            var passCount = attempts.Count(q => q.IsPassed);
            var failCount = attempts.Count(q => !q.IsPassed);

            return Ok(new { Passed = passCount, Failed = failCount });
        }

        // POST: api/QuizAttemp/Complete/{attemptId}
        [HttpPost("Complete/{attemptId}")]
        public async Task<IActionResult> CompleteQuizAttempt(string attemptId)
        {
            var attempt = await _unitOfWork.QuizAttempRepository.GetByIdAsync(attemptId);
            if (attempt == null)
                return NotFound("Quiz attempt not found.");

            attempt.CompletedAt = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync();

            return Ok(new { attempt.CompletedAt, attempt.Duration });
        }





    }
}
