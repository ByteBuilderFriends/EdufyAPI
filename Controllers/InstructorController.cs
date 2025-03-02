using AutoMapper;
using EdufyAPI.DTOs.InstructorDTOs;
using EdufyAPI.Helpers;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class InstructorController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        private readonly string InstructorProfilePictureFolder = "instructor-profile-picture";

        // GET: api/Instructor
        [HttpGet]
        public async Task<IActionResult> GetAllInstructors()
        {
            var instructors = await _unitOfWork.InstructorRepository.GetAllAsync();

            if (instructors == null)
                return Ok();

            var instructorDtos = _mapper.Map<IEnumerable<InstructorReadDTO>>(instructors);
            foreach (var instructorDto in instructorDtos)
            {
                if (instructorDto.ProfilePictureUrl != null)
                    instructorDto.ProfilePictureUrl = ConstructFileUrlHelper.ConstructFileUrl(Request, InstructorProfilePictureFolder, instructorDto.ProfilePictureUrl);
            }

            return Ok(instructorDtos);
        }

        // GET: api/Instructor/5

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstructorById(string id)
        {
            var instructor = await _unitOfWork.InstructorRepository.GetByIdAsync(id);
            if (instructor == null)
                return NotFound();
            var instructorDto = _mapper.Map<InstructorReadDTO>(instructor);
            if (instructorDto.ProfilePictureUrl != null)
                instructorDto.ProfilePictureUrl = ConstructFileUrlHelper.ConstructFileUrl(Request, InstructorProfilePictureFolder, instructorDto.ProfilePictureUrl);
            return Ok(instructorDto);
        }

        // POST: api/Course/5/Instructor

        [HttpPost("{id}/Instructor")]
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

        // Upload Course
        //public async Task<IActionResult> UploadCourse(Course course)
        //{
        //    return Ok();
        //}


    }
}
