using AutoMapper;
using EdufyAPI.DTOs.QuizModelsDTOs.QuizDTOs;
using EdufyAPI.Models;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class QuizController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public QuizController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // GET: api/Quiz
    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuizReadDTO>>> GetQuizzes()
    {
        var quizzes = await _unitOfWork.QuizRepository.GetAllAsync();
        quizzes = quizzes.Where(q => !q.IsDeleted).ToList();
        var quizDTOs = _mapper.Map<IEnumerable<QuizReadDTO>>(quizzes);
        return Ok(quizDTOs);
    }

    // GET: api/Quiz/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<QuizReadDTO>> GetQuizById(string id)
    {
        var quiz = await _unitOfWork.QuizRepository.GetByIdAsync(id);
        if (quiz == null || quiz.IsDeleted)
            return NotFound(new { Message = "Quiz not found." });

        var quizDTO = _mapper.Map<QuizReadDTO>(quiz);
        return Ok(quizDTO);
    }

    // POST: api/Quiz
    [HttpPost]
    public async Task<ActionResult<QuizReadDTO>> CreateQuiz([FromBody] QuizCreateDTO quizCreateDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var lesson = await _unitOfWork.LessonRepository.GetByIdAsync(quizCreateDTO.LessonId);
        if (lesson == null || lesson.IsDeleted) return BadRequest(new { Message = "Invalid LessonId." });

        var quiz = _mapper.Map<Quiz>(quizCreateDTO);
        await _unitOfWork.QuizRepository.AddAsync(quiz);
        await _unitOfWork.SaveChangesAsync();

        var quizReadDTO = _mapper.Map<QuizReadDTO>(quiz);
        return CreatedAtAction(nameof(GetQuizById), new { id = quizReadDTO.Id }, quizReadDTO);
    }

    // PUT: api/Quiz/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuiz(string id, [FromBody] QuizUpdateDTO quizUpdateDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var quiz = await _unitOfWork.QuizRepository.GetByIdAsync(id);
        if (quiz == null || quiz.IsDeleted) return NotFound(new { Message = "Quiz not found." });

        _mapper.Map(quizUpdateDTO, quiz);
        quiz.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.QuizRepository.UpdateAsync(quiz);
        await _unitOfWork.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Quiz/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuiz(string id)
    {
        var quiz = await _unitOfWork.QuizRepository.GetByIdAsync(id);
        if (quiz == null)
            return NotFound(new { Message = "Quiz not found." });

        quiz.IsDeleted = true;
        quiz.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.QuizRepository.UpdateAsync(quiz);
        await _unitOfWork.SaveChangesAsync();

        return NoContent();
    }
}
