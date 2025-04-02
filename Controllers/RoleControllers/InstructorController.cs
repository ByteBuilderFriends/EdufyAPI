using AutoMapper;
using EdufyAPI.DTOs.InstructorDTOs;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers.RoleControllers
{
    /// <summary>
    /// Controller for managing instructor-related operations
    /// </summary>
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class InstructorController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Retrieves all instructors
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/Instructor/GetAllInstructors
        ///     
        /// </remarks>
        /// <returns>List of instructors</returns>
        /// <response code="200">Returns list of instructors (might be empty)</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllInstructors()
        {
            var instructors = await _unitOfWork.InstructorRepository.GetAllAsync();

            if (instructors == null)
                return Ok();

            var instructorDtos = _mapper.Map<IEnumerable<InstructorReadDTO>>(instructors);

            return Ok(instructorDtos);
        }

        /// <summary>
        /// Retrieves a specific instructor by ID
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/Instructor/GetInstructorById/abc123
        ///     
        /// </remarks>
        /// <param name="id">Instructor ID</param>
        /// <returns>Instructor details</returns>
        /// <response code="200">Returns requested instructor</response>
        /// <response code="404">Instructor not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInstructorById(string id)
        {
            var instructor = await _unitOfWork.InstructorRepository.GetByIdAsync(id);
            if (instructor == null)
                return NotFound();

            var instructorDto = _mapper.Map<InstructorReadDTO>(instructor);
            return Ok(instructorDto);
        }

        /// <summary>
        /// Retrieves the instructor associated with a specific course
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Instructor/GetInstructorByCourseId/456/course
        ///     
        /// </remarks>
        /// <param name="id">Course ID</param>
        /// <returns>Instructor details for course</returns>
        /// <response code="200">Returns associated instructor</response>
        /// <response code="404">Course or instructor not found</response>
        [HttpGet("{id}/Instructor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInstructorByCourseId(string id)
        {
            var course = await _unitOfWork.CourseRepository.GetByIdAsync(id);
            if (course == null)
                return NotFound();

            var instructor = await _unitOfWork.InstructorRepository.GetByIdAsync(course.InstructorId);
            if (instructor == null)
                return NotFound();

            var instructorDto = _mapper.Map<InstructorReadDTO>(instructor);
            return Ok(instructorDto);
        }
    }
}