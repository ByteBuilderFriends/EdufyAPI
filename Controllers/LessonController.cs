using AutoMapper;
using EdufyAPI.DTOs.LessonDTOs;
using EdufyAPI.Models;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LessonController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Lesson
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonReadDTO>>> GetLessons()
        {
            var lessons = await _unitOfWork.LessonRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<LessonReadDTO>>(lessons));
        }

        // GET: api/Lesson/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<LessonReadDTO>> GetLessonByID(int id)
        {
            var lesson = await _unitOfWork.LessonRepository.GetByIdAsync(id);
            if (lesson == null) return NotFound();
            return Ok(_mapper.Map<LessonReadDTO>(lesson));
        }

        // POST: api/Lesson
        [HttpPost]
        public async Task<ActionResult<LessonReadDTO>> CreateLesson(LessonCreateDTO createLessonDto)
        {
            var lesson = _mapper.Map<Lesson>(createLessonDto);
            await _unitOfWork.LessonRepository.AddAsync(lesson);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLessonByID), new { id = lesson.Id }, _mapper.Map<LessonReadDTO>(lesson));
        }

        // PUT: api/Lesson/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLesson(int id, LessonUpdateDTO updateLessonDto)
        {
            var lesson = await _unitOfWork.LessonRepository.GetByIdAsync(id);
            if (lesson == null) return NotFound();
            _mapper.Map(updateLessonDto, lesson);
            await _unitOfWork.LessonRepository.UpdateAsync(lesson);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Lesson/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var result = await _unitOfWork.LessonRepository.DeleteAsync(id);
            if (result == null) return NotFound();
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}