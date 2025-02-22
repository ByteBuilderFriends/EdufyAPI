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

    // ✅ Get all progress records
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProgressReadDTO>>> GetAllProgresses()
    {
        var progresses = await _unitOfWork.ProgressRepository.GetAllAsync();
        var progressDTOs = _mapper.Map<IReadOnlyList<ProgressReadDTO>>(progresses);
        return Ok(progressDTOs);
    }

    // ✅ Get progress by Id
    [HttpGet("{id}")]
    public async Task<ActionResult<ProgressReadDTO>> GetProgressById(string id)
    {
        var progress = await _unitOfWork.ProgressRepository.GetByIdAsync(id);
        if (progress == null) return NotFound();

        var progressDTO = _mapper.Map<ProgressReadDTO>(progress);
        return Ok(progressDTO);
    }

    // ✅ Get progress by Student Id
    [HttpGet("ByStudent/{studentId}")]
    public async Task<ActionResult<IEnumerable<ProgressReadDTO>>> GetProgressByStudentId(string studentId)
    {
        var progresses = await _unitOfWork.ProgressRepository.GetAllAsync();
        var filteredProgresses = progresses.Where(p => p.CourseId == studentId).ToList();
        var progressDTOs = _mapper.Map<IReadOnlyList<ProgressReadDTO>>(filteredProgresses);
        return Ok(progressDTOs);
    }

    // ✅ Get progress by Course Id
    [HttpGet("ByCourse/{courseId}")]
    public async Task<ActionResult<IEnumerable<ProgressReadDTO>>> GetProgressByCourseId(string courseId)
    {
        var progresses = await _unitOfWork.ProgressRepository.GetAllAsync();
        var filteredProgresses = progresses.Where(p => p.CourseId == courseId).ToList();
        var progressDTOs = _mapper.Map<IReadOnlyList<ProgressReadDTO>>(filteredProgresses);
        return Ok(progressDTOs);
    }


    // ✅ Create new progress
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

    // ✅ Update progress
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

    // ✅ Delete progress
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProgress(string id)
    {
        var deleted = await _unitOfWork.ProgressRepository.DeleteAsync(id);
        if (!deleted) return NotFound();

        await _unitOfWork.SaveChangesAsync();
        return NoContent();
    }

    // ✅ Mark progress as completed
    [HttpPut("MarkAsCompleted/{id}")]
    public async Task<ActionResult> MarkProgressAsCompleted(string id)
    {
        var progress = await _unitOfWork.ProgressRepository.GetByIdAsync(id);
        if (progress == null) return NotFound();

        if (!progress.IsCompleted) return BadRequest("Progress is not yet completed.");

        await _unitOfWork.SaveChangesAsync();
        return NoContent();
    }
}
