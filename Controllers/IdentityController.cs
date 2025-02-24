using AutoMapper;
using EdufyAPI.DTOs.IdentityDTOs;
using EdufyAPI.Models.Roles;
using EdufyAPI.Repository.Interfaces;
using EdufyAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace EdufyAPI.Controllers
{
    /// <summary>
    /// Controller for handling user authentication (Register, Login, Logout, and JWT generation).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        /// <summary>
        /// Constructor to initialize IdentityController with dependency injection.
        /// </summary>
        public IdentityController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IConfiguration config,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Registers a new user with email and password.
        /// </summary>
        /// <param name="model">User registration details.</param>
        /// <returns>Returns success or failure response.</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // MailAddress.User is used to take the username part of the email.
            var user = new AppUser
            {
                UserName = new MailAddress(model.Email).User,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            // Assign the selected role (Student or Instructor)
            var roleAssignment = await _userManager.AddToRoleAsync(user, model.Role);
            if (!roleAssignment.Succeeded)
                return BadRequest(roleAssignment.Errors);

            // If user is a student, add to Student table
            if (model.Role == "Student")
            {
                var student = _mapper.Map<Student>(model);
                await _unitOfWork.StudentRepository.AddAsync(student);
            }

            // If user is an instructor, add to Instructor table
            if (model.Role == "Instructor")
            {
                var instructor = _mapper.Map<Instructor>(model);
                await _unitOfWork.InstructorRepository.AddAsync(instructor);
            }


            return Ok(new { Message = "User registered successfully!" });
        }

        /// <summary>
        /// Logs in a user and generates a JWT token.
        /// </summary>
        /// <param name="model">User login credentials.</param>
        /// <returns>JWT Token on successful authentication.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Determine if the input is an email
            bool isEmail = new EmailAddressAttribute().IsValid(model.Email);

            // Retrieve the user using email or username
            var user = isEmail
                ? await _userManager.FindByEmailAsync(model.Email)
                : await _userManager.FindByNameAsync(model.Email);

            if (user == null)
                return Unauthorized(new { Message = "Invalid credentials" });

            // Sign in the user with Email or username
            //var username = new EmailAddressAttribute().IsValid(model.Email) ? new MailAddress(model.Email).User : model.Email;


            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
                return Unauthorized(new { Message = "Invalid credentials" });

            var token = GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        /// <summary>
        /// Logs out the authenticated user.
        /// </summary>
        /// <returns>Success message.</returns>
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { Message = "Logged out successfully!" });
        }

        // Get All Users
        [HttpGet("Users")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("Users/{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }


        [HttpPut("update-email")]
        [Authorize]
        public async Task<IActionResult> UpdateEmail([FromBody] UpdateEmailDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUser = await _userManager.FindByIdAsync(model.UserId);
            if (appUser == null)
                return NotFound("User not found.");

            // Ensure only the user or an admin can update the email
            var loggedInUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var isAdmin = User.IsInRole("Admin");

            if (!isAdmin && loggedInUserId != model.UserId)
                return Forbid();

            // Change email & generate confirmation token
            var token = await _userManager.GenerateChangeEmailTokenAsync(appUser, model.NewEmail);
            var result = await _userManager.ChangeEmailAsync(appUser, model.NewEmail, token);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { Message = "Email updated successfully. Please verify your new email." });
        }


        [HttpPut("update-password")]
        [Authorize]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUser = await _userManager.FindByIdAsync(model.UserId);
            if (appUser == null)
                return NotFound("User not found.");

            var loggedInUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var isAdmin = User.IsInRole("Admin");

            if (!isAdmin && loggedInUserId != model.UserId)
                return Forbid();

            IdentityResult result;

            if (isAdmin)
            {
                // Admins can reset password directly
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(appUser);
                result = await _userManager.ResetPasswordAsync(appUser, resetToken, model.NewPassword);
            }
            else
            {
                // Regular users must provide old password
                result = await _userManager.ChangePasswordAsync(appUser, model.OldPassword, model.NewPassword);
            }

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { Message = "Password updated successfully!" });
        }


        [HttpPut("update-name")]
        [Authorize]
        public async Task<IActionResult> UpdateName([FromBody] UpdateNameDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUser = await _userManager.FindByIdAsync(model.UserId);
            if (appUser == null)
                return NotFound("User not found.");

            var loggedInUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var isAdmin = User.IsInRole("Admin");

            if (!isAdmin && loggedInUserId != model.UserId)
                return Forbid();

            // Update only the name fields
            appUser.FirstName = model.FirstName;
            appUser.LastName = model.LastName;

            var result = await _userManager.UpdateAsync(appUser);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { Message = "Name updated successfully!" });
        }



        /// <summary>
        /// Generates a JWT token for the authenticated user.
        /// </summary>
        /// <param name="user">Authenticated IdentityUser.</param>
        /// <returns>JWT Token as a string.</returns>
        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var now = DateTime.UtcNow;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                }),
                NotBefore = now,
                Expires = now.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
