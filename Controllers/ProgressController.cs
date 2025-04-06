using AutoMapper;
using EdufyAPI.DTOs.ProgressDTOs;
using EdufyAPI.Models;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProgressController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProgressController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all progress records.
    /// </summary>
    /// <returns>A list of progress records.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProgressReadDTO>>> GetAllProgresses()
    {
        var progresses = await _unitOfWork.ProgressRepository.GetAllAsync();
        var progressDTOs = _mapper.Map<IReadOnlyList<ProgressReadDTO>>(progresses);
        return Ok(progressDTOs);
    }

    /// <summary>
    /// Retrieves a progress record by its ID.
    /// </summary>
    /// <param name="id">The progress ID.</param>
    /// <returns>The progress record.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ProgressReadDTO>> GetProgressById(string id)
    {
        var progress = await _unitOfWork.ProgressRepository.GetByIdAsync(id);
        if (progress == null) return NotFound();

        var progressDTO = _mapper.Map<ProgressReadDTO>(progress);
        return Ok(progressDTO);
    }

    /// <summary>
    /// Retrieves all progress records for a specific student.
    /// </summary>
    /// <param name="studentId">The student ID.</param>
    /// <returns>A list of progress records for the student.</returns>
    [HttpGet("ByStudent/{studentId}")]
    public async Task<ActionResult<IEnumerable<ProgressReadDTO>>> GetProgressByStudentId(string studentId)
    {
        var progresses = await _unitOfWork.ProgressRepository.GetAllAsync();
        var filteredProgresses = progresses.Where(p => p.StudentId == studentId).ToList();
        var progressDTOs = _mapper.Map<IReadOnlyList<ProgressReadDTO>>(filteredProgresses);
        return Ok(progressDTOs);
    }

    /// <summary>
    /// Retrieves all progress records for a specific course.
    /// </summary>
    /// <param name="courseId">The course ID.</param>
    /// <returns>A list of progress records for the course.</returns>
    [HttpGet("ByCourse/{courseId}")]
    public async Task<ActionResult<IEnumerable<ProgressReadDTO>>> GetProgressByCourseId(string courseId)
    {
        var progresses = await _unitOfWork.ProgressRepository.GetAllAsync();
        var filteredProgresses = progresses.Where(p => p.CourseId == courseId).ToList();
        var progressDTOs = _mapper.Map<IReadOnlyList<ProgressReadDTO>>(filteredProgresses);
        return Ok(progressDTOs);
    }

    /// <summary>
    /// Creates a new progress record.
    /// </summary>
    /// <param name="dto">The progress creation data.</param>
    /// <returns>The created progress record.</returns>
    [HttpPost]
    public async Task<ActionResult<ProgressReadDTO>> CreateProgress([FromBody] ProgressCreateDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var progress = _mapper.Map<Progress>(dto);
        await _unitOfWork.ProgressRepository.AddAsync(progress);
        await _unitOfWork.SaveChangesAsync();

        var progressReadDTO = _mapper.Map<ProgressReadDTO>(progress);
        return CreatedAtAction(nameof(GetProgressById), new { id = progress.Id }, progressReadDTO);
    }

    /// <summary>
    /// Updates an existing progress record.
    /// </summary>
    /// <param name="id">The progress ID.</param>
    /// <param name="dto">The updated progress data.</param>
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProgress(string id, [FromBody] ProgressUpdateDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var existingProgress = await _unitOfWork.ProgressRepository.GetByIdAsync(id);
        if (existingProgress == null) return NotFound();

        _mapper.Map(dto, existingProgress);
        await _unitOfWork.ProgressRepository.UpdateAsync(existingProgress);
        await _unitOfWork.SaveChangesAsync();

        return NoContent();
    }

    /// <summary>
    /// Deletes a progress record.
    /// </summary>
    /// <param name="id">The progress ID.</param>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProgress(string id)
    {
        var deleted = await _unitOfWork.ProgressRepository.DeleteAsync(id);
        if (!deleted) return NotFound();

        await _unitOfWork.SaveChangesAsync();
        return NoContent();
    }

    /// <summary>
    /// Marks a progress record as completed.
    /// </summary>
    /// <param name="id">The progress ID.</param>
    [HttpPut("MarkAsCompleted/{id}")]
    public async Task<ActionResult> MarkProgressAsCompleted(string id)
    {
        var progress = await _unitOfWork.ProgressRepository.GetByIdAsync(id);
        if (progress == null) return NotFound();

        if (!progress.IsCompleted) return BadRequest("Progress is not yet completed.");

        progress.CompletedProgress = true;
        await _unitOfWork.SaveChangesAsync();
        return NoContent();
    }
}
