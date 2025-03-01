using AutoMapper;
using EdufyAPI.DTOs;
using EdufyAPI.DTOs.QuizModelsDTOs.QuizDTOs;
using EdufyAPI.Models;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller][action]")]
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
    public async Task<ActionResult<IEnumerable<QuizReadDTO>>> GetAllQuizzes()
    {
        var quizzes = await _unitOfWork.QuizRepository.GetAllAsync();
        if (!quizzes.Any())
            return Ok(Enumerable.Empty<CourseReadDTO>());

        var quizDTOs = _mapper.Map<IEnumerable<QuizReadDTO>>(quizzes);
        return Ok(quizDTOs);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuizReadDTO>>> GetUnDeletedQuizzes()
    {
        var quizzes = await _unitOfWork.QuizRepository.GetByCondition(q => !q.IsDeleted);
        if (!quizzes.Any())
            return Ok(Enumerable.Empty<CourseReadDTO>());

        var quizDTOs = _mapper.Map<IEnumerable<QuizReadDTO>>(quizzes);
        return Ok(quizDTOs);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuizReadDTO>>> GetDeletedQuizzes()
    {
        var quizzes = await _unitOfWork.QuizRepository.GetByCondition(q => q.IsDeleted);
        if (!quizzes.Any())
            return Ok(Enumerable.Empty<CourseReadDTO>());

        var quizDTOs = _mapper.Map<IEnumerable<QuizReadDTO>>(quizzes);
        return Ok(quizDTOs);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuizReadDTO>>> GetActiveQuizzes()
    {
        var quizzes = await _unitOfWork.QuizRepository.GetByCondition(q => q.IsActive);
        if (!quizzes.Any())
            return Ok(Enumerable.Empty<CourseReadDTO>());

        var quizDTOs = _mapper.Map<IEnumerable<QuizReadDTO>>(quizzes);
        return Ok(quizDTOs);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuizReadDTO>>> GetUnActiveQuizzes()
    {
        var quizzes = await _unitOfWork.QuizRepository.GetByCondition(q => !q.IsActive);
        if (!quizzes.Any())
            return Ok(Enumerable.Empty<CourseReadDTO>());

        var quizDTOs = _mapper.Map<IEnumerable<QuizReadDTO>>(quizzes);
        return Ok(quizDTOs);
    }

    // GET: api/Quiz/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<QuizReadDTO>> GetQuizById(string id)
    {
        var quiz = await _unitOfWork.QuizRepository.GetByIdAsync(id);
        if (quiz == null || quiz.IsDeleted)
            return NotFound("Quiz not found.");

        var quizDTO = _mapper.Map<QuizReadDTO>(quiz);
        return Ok(quizDTO);
    }

    [HttpGet("{courseId}")]
    public async Task<ActionResult<IEnumerable<QuizReadDTO>>> GetCourseQuizzes(string courseId)
    {
        var course = _unitOfWork.CourseRepository.GetByIdAsync(courseId);
        if (course == null) return BadRequest("Invalid course id");

        var quizzes = await _unitOfWork.QuizRepository.GetByCondition(q => q.Lesson.CourseId == courseId);
        if (!quizzes.Any())
            return Ok(Enumerable.Empty<CourseReadDTO>());

        var quizDTOs = _mapper.Map<IEnumerable<QuizReadDTO>>(quizzes);
        return Ok(quizDTOs);
    }

    //[HttpGet("{lessonId}")]//
    //public async Task<ActionResult<QuizReadDTO>> GetQuizByLessonId(string lessonId)
    //{
    //    var lesson = await _unitOfWork.LessonRepository.GetByIdAsync(lessonId);
    //    if (lesson == null) return BadRequest("Invalid lesson id");

    //    var quiz = await _unitOfWork.QuizRepository.GetByCondition(q => q.Lesson.Id == lessonId);
    //    if (quiz == null)
    //        return Ok("There is no quiz in this lesson");

    //    var quizDTO = _mapper.Map<QuizReadDTO>(quiz);
    //    return Ok(quizDTO);
    //}

    // POST: api/Quiz
    [HttpPost]
    public async Task<ActionResult<QuizReadDTO>> CreateQuiz([FromBody] QuizCreateDTO quizCreateDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var lesson = await _unitOfWork.LessonRepository.GetByIdAsync(quizCreateDTO.LessonId);
        if (lesson == null) return BadRequest("Invalid LessonId.");
        if (lesson.Quiz != null && lesson.Quiz.Id != null) return BadRequest("This lesson already has a quiz");

        var quiz = _mapper.Map<Quiz>(quizCreateDTO);
        await _unitOfWork.QuizRepository.AddAsync(quiz);

        var quizReadDTO = _mapper.Map<QuizReadDTO>(quiz);
        return CreatedAtAction(nameof(GetQuizById), new { id = quizReadDTO.Id }, quizReadDTO);
    }

    // PUT: api/Quiz/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuiz(string id, [FromBody] QuizUpdateDTO quizUpdateDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var quiz = await _unitOfWork.QuizRepository.GetByIdAsync(id);
        if (quiz == null || quiz.IsDeleted) return NotFound("Quiz not found.");

        _mapper.Map(quizUpdateDTO, quiz);
        quiz.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.QuizRepository.UpdateAsync(quiz);

        return NoContent();
    }

    // DELETE: api/Quiz/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuiz(string id)
    {
        var quiz = await _unitOfWork.QuizRepository.GetByIdAsync(id);
        if (quiz == null)
            return NotFound("Quiz not found.");

        quiz.IsDeleted = true;
        quiz.UpdatedAt = DateTime.UtcNow;

        // Save it in DB as deleted not delete it to access it after complete
        await _unitOfWork.QuizRepository.UpdateAsync(quiz);
        return NoContent();
    }
}
