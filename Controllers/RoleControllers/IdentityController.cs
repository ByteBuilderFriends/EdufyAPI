using AutoMapper;
using EdufyAPI.DTOs.IdentityDTOs;
using EdufyAPI.Enums;
using EdufyAPI.Helpers;
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

namespace EdufyAPI.Controllers.RoleControllers
{
    /// <summary>
    /// Controller for handling user authentication (Register, Login, Logout, and JWT generation).
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<IdentityController> _logger;

        /// <summary>
        /// Constructor to initialize IdentityController with dependency injection.
        /// </summary>
        public IdentityController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IConfiguration config,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ILogger<IdentityController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Registers a new user with email and password
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Identity/register
        ///     FormData:
        ///     - FirstName: "John"
        ///     - LastName: "Doe"
        ///     - Email: "john.doe@example.com"
        ///     - Password: "P@ssw0rd!"
        ///     - PhoneNumber: "123-456-7890"
        ///     - Role: 0 (Student) or 1 (Instructor)
        ///     - ProfilePicture: [file upload]
        ///     
        /// </remarks>
        /// <param name="model">User registration details including profile picture</param>
        /// <returns>Success message or error details</returns>
        /// <response code="200">User registered successfully</response>
        /// <response code="400">Invalid input data or registration error</response>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Add the user Picture
            var imageUrl = await FileUploadHelper.UploadFileAsync(model.ProfilePicture, "user-profile");

            // Construct the full URL immediately during registration
            imageUrl = ConstructFileUrlHelper.ConstructFileUrl(Request, "user-profile", imageUrl);

            // MailAddress.User is used to take the username part of the email.
            var user = new AppUser
            {
                UserName = new MailAddress(model.Email).User,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                ProfilePictureUrl = imageUrl
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            // Assign the selected role (Student or Instructor)
            var roleAssignment = await _userManager.AddToRoleAsync(user, model.Role.ToString());
            if (!roleAssignment.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return BadRequest(roleAssignment.Errors);
            }

            // Student and Instructor have different tables for better query performance
            // Add user to the corresponding table
            switch (model.Role)
            {
                case Role.Student:
                    var student = _mapper.Map<Student>(model);
                    await _unitOfWork.StudentRepository.AddAsync(student);
                    break;

                case Role.Instructor:
                    var instructor = _mapper.Map<Instructor>(model);
                    await _unitOfWork.InstructorRepository.AddAsync(instructor);
                    break;
            }

            // Log the successful login
            _logger.LogInformation($"User {user.Id} registered successfully.");
            return Ok(new { Message = "User registered successfully!" });
        }

        /// <summary>
        /// Authenticates a user and generates JWT token
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/Identity/login
        ///     {
        ///         "email": "john.doe@example.com",
        ///         "password": "P@ssw0rd!"
        ///     }
        ///     
        /// </remarks>
        /// <param name="model">User credentials (email/username and password)</param>
        /// <returns>JWT token for authenticated requests</returns>
        /// <response code="200">Returns authentication token</response>
        /// <response code="400">Invalid request format</response>
        /// <response code="401">Invalid credentials</response>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Check if input is an email
            bool isEmail = new EmailAddressAttribute().IsValid(model.Email);

            // Normalize the email correctly
            var normalizedEmail = isEmail ? _userManager.NormalizeEmail(model.Email) : null;

            // Find the user by email or username
            var user = isEmail
                ? await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedEmail == normalizedEmail)
                : await _userManager.FindByNameAsync(model.Email);

            // Note: ✅ Emails must be normalized manually because we query using FirstOrDefaultAsync and compare against NormalizedEmail.
            // NOTE: ✅ Usernames don't need manual normalization because FindByNameAsync already handles it.

            if (user == null)
                return Problem("Invalid credentials", statusCode: 401);

            // Ensure correct username is used for sign-in
            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);

            if (!result.Succeeded)
            {
                _logger.LogWarning($"Failed login attempt for {model.Email} at {DateTime.UtcNow}.");
                return Problem("Invalid credentials", statusCode: 401);
            }

            // Generate and return JWT token
            var token = GenerateJwtToken(user);


            return Ok(new { Token = token });
        }




        /// <summary>
        /// Logs out the currently authenticated user
        /// </summary>
        /// <returns>Empty response</returns>
        /// <response code="204">Successfully logged out</response>
        /// <response code="401">User not authenticated</response>
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized(new { Message = "User is not logged in." });

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _logger.LogInformation($"User {userId} logged out at {DateTime.UtcNow}.");

            await _signInManager.SignOutAsync();

            return NoContent(); // RESTful response
        }


        // Get All Users
        /// <summary>
        /// Retrieves all registered users (Admin only)
        /// </summary>
        /// <returns>List of all users</returns>
        /// <response code="200">Returns user list</response>
        /// <response code="401">Unauthorized access</response>
        /// <response code="403">Insufficient privileges</response>
        [HttpGet("Users")]
        //[Authorize("Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();

            return Ok(users);
        }

        /// <summary>
        /// Retrieves a specific user by ID
        /// </summary>
        /// <param name="id">User ID to retrieve</param>
        /// <returns>User details</returns>
        /// <response code="200">Returns requested user</response>
        /// <response code="404">User not found</response>
        [HttpGet("Users/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Updates user's email address
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/Identity/update-email
        ///     {
        ///         "userId": "123e4567-e89b-12d3-a456-426614174000",
        ///         "newEmail": "new.email@example.com"
        ///     }
        ///     
        /// </remarks>
        /// <param name="model">Email update details</param>
        /// <returns>Success message with new username</returns>
        /// <response code="200">Email updated successfully</response>
        /// <response code="400">Invalid input data</response>
        /// <response code="403">Unauthorized update attempt</response>
        /// <response code="404">User not found</response>
        [HttpPut("update-email")]
        [Authorize]
        public async Task<IActionResult> UpdateEmail([FromBody] UpdateEmailDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Get the user from DB
            var appUser = await _userManager.FindByIdAsync(model.UserId);
            if (appUser == null)
                return NotFound("User not found.");

            // Ensure only the user or an admin can update the email
            var loggedInUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var isAdmin = User.IsInRole("Admin");

            if (!isAdmin && loggedInUserId != model.UserId)
                return Forbid(); // 403 Forbidden

            // Validate new email
            if (string.IsNullOrWhiteSpace(model.NewEmail) || !new EmailAddressAttribute().IsValid(model.NewEmail))
                return BadRequest(new { Message = "Invalid email format." });

            // Generate a new username from the email
            string newUserName = model.NewEmail.Split('@')[0];

            // Check if the username is already taken
            if (await _userManager.FindByNameAsync(newUserName) != null)
            {
                newUserName += new Random().Next(1000, 9999); // Append random number if needed
            }

            // Update the email and username
            appUser.Email = model.NewEmail;
            appUser.UserName = newUserName;

            var result = await _userManager.UpdateAsync(appUser);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { Message = "Email updated successfully!", UserName = newUserName });
        }

        /// <summary>
        /// Updates user's password
        /// </summary>
        /// <remarks>
        /// Regular users must provide old password, admins can reset directly
        /// 
        /// Sample user request:
        /// 
        ///     PUT /api/Identity/update-password
        ///     {
        ///         "userId": "123e4567-e89b-12d3-a456-426614174000",
        ///         "oldPassword": "oldPassword123",
        ///         "newPassword": "newPassword456"
        ///     }
        ///     
        /// </remarks>
        /// <param name="model">Password update details</param>
        /// <returns>Success message</returns>
        /// <response code="200">Password updated successfully</response>
        /// <response code="400">Invalid input data</response>
        /// <response code="403">Unauthorized update attempt</response>
        /// <response code="404">User not found</response>
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

        /// <summary>
        /// Updates user's first and last name
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT /api/Identity/update-name
        ///     {
        ///         "userId": "123e4567-e89b-12d3-a456-426614174000",
        ///         "firstName": "John",
        ///         "lastName": "Smith"
        ///     }
        ///     
        /// </remarks>
        /// <param name="model">Name update details</param>
        /// <returns>Success message</returns>
        /// <response code="200">Name updated successfully</response>
        /// <response code="400">Invalid input data</response>
        /// <response code="403">Unauthorized update attempt</response>
        /// <response code="404">User not found</response>
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
        /// Deletes a user account
        /// </summary>
        /// <param name="id">ID of user to delete</param>
        /// <returns>Success message</returns>
        /// <response code="200">User deleted successfully</response>
        /// <response code="400">Deletion failed</response>
        /// <response code="404">User not found</response>
        [HttpDelete("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound("User not found.");

            // Delete also from Student or Instructor table
            if (await _userManager.IsInRoleAsync(user, "Student"))
            {
                var student = await _unitOfWork.StudentRepository.GetByIdAsync(id);
                if (student != null)
                    await _unitOfWork.StudentRepository.DeleteAsync(student);
            }

            if (await _userManager.IsInRoleAsync(user, "Instructor"))
            {
                var instructor = await _unitOfWork.InstructorRepository.GetByIdAsync(id);
                if (instructor != null)
                    await _unitOfWork.InstructorRepository.DeleteAsync(instructor);
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return BadRequest(result.Errors);
            return Ok(new { Message = "User deleted successfully!" });
        }




        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"] ?? throw new ArgumentNullException("JwtSettings:Key"));
            var tokenHandler = new JwtSecurityTokenHandler();
            var now = DateTime.UtcNow;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id ?? string.Empty),            // User ID
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName ?? string.Empty), // Correct claim for UserName
                        new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),      // Email
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),         // Unique Token ID
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
