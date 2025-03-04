using AutoMapper;
using EdufyAPI.DTOs.QuizModelsDTOs.AnswerDTOs;
using EdufyAPI.Models.QuizModels;
using EdufyAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EdufyAPI.Controllers.QuizModelsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAnswerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentAnswerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        // GET: api/StudentAnswer
        [HttpGet]
        public async Task<IActionResult> GetAllStudentAnswers()
        {
            var studentAnswers = await _unitOfWork.StudentAnswerRepository.GetAllAsync();
            if (studentAnswers == null)
                return Ok(Enumerable.Empty<StudentAnswerReadDTO>());
            var studentAnswerDTOs = _mapper.Map<IEnumerable<StudentAnswerReadDTO>>(studentAnswers);
            return Ok(studentAnswerDTOs);
        }

        // GET: api/StudentAnswer/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentAnswerById(string id)
        {
            var studentAnswer = await _unitOfWork.StudentAnswerRepository.GetByIdAsync(id);
            if (studentAnswer == null)
                return NotFound("Student Answer not found.");
            var studentAnswerDTO = _mapper.Map<StudentAnswerReadDTO>(studentAnswer);
            return Ok(studentAnswerDTO);
        }

        // POST: api/StudentAnswer
        [HttpPost]
        public async Task<IActionResult> CreateStudentAnswer(StudentAnswerReadDTO studentAnswerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var studentAnswer = _mapper.Map<StudentAnswer>(studentAnswerDTO);
            await _unitOfWork.StudentAnswerRepository.AddAsync(studentAnswer);
            var createdStudentAnswerDTO = _mapper.Map<StudentAnswerReadDTO>(studentAnswer);
            return CreatedAtAction(nameof(GetStudentAnswerById), new { id = studentAnswer.Id }, createdStudentAnswerDTO);

        }

        // PUT: api/StudentAnswer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentAnswer(string id, StudentAnswerReadDTO studentAnswerDTO)
        {
            // Check for ID mismatch
            if (id != studentAnswerDTO.Id)
                return BadRequest("Id mismatch.");

            // Retrieve the student answer asynchronously
            var studentAnswer = await _unitOfWork.StudentAnswerRepository.GetByIdAsync(id);

            // Check if the student answer exists
            if (studentAnswer == null)
                return NotFound($"Student Answer with ID {id} not found.");

            // Map DTO to the student answer entity
            _mapper.Map(studentAnswerDTO, studentAnswer);

            // Update the student answer
            await _unitOfWork.StudentAnswerRepository.UpdateAsync(studentAnswer);

            // Save changes to the database
            await _unitOfWork.SaveChangesAsync();

            // Return NoContent (success)
            return NoContent();
        }

        [HttpPut("{id}/correct")]
        public async Task<IActionResult> CorrectStudentAnswer(string id)
        {
            // Retrieve the student answer asynchronously
            var studentAnswer = await _unitOfWork.StudentAnswerRepository.GetByIdAsync(id);

            // Check if the student answer exists
            if (studentAnswer == null)
                return NotFound($"Student Answer with ID {id} not found.");

            // Ensure the related question is loaded
            var question = await _unitOfWork.QuestionRepository.GetByIdAsync(studentAnswer.QuestionId);
            if (question == null)
                return NotFound($"Question with ID {studentAnswer.QuestionId} not found.");

            // Validate the submitted answer against the correct answer
            if (!string.IsNullOrEmpty(studentAnswer.SubmittedAnswer) &&
                !string.IsNullOrEmpty(question.Answer) &&
                studentAnswer.SubmittedAnswer.Trim().ToLower() == question.Answer.Trim().ToLower())
            {
                studentAnswer.IsCorrect = true;
            }
            else
            {
                studentAnswer.IsCorrect = false;
            }

            // Update the student answer
            await _unitOfWork.StudentAnswerRepository.UpdateAsync(studentAnswer);

            // Return success response
            return NoContent();
        }

    }
}
