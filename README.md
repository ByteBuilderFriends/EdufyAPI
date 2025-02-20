# Template

This is a .NET Core Web API template that includes user authentication using ASP.NET Identity and JWT token generation. The template is structured to provide essential functionalities such as user registration, login, logout, and secure API endpoints.

## Table of Contents
- [Project Structure](#project-structure)
- [Installation & Setup](#installation--setup)
- [Configuration](#configuration)
- [Endpoints](#endpoints)
- [Code Explanation](#code-explanation)
  - [IdentityController.cs](#identitycontrollercs)
  - [ViewModels](#viewmodels)
  - [Authentication Setup](#authentication-setup)
  - [Swagger Integration](#swagger-integration)
- [Deployment Guide](#deployment-guide)
- [License](#license)

---

## Project Structure
```
Template/
│── Controllers/
│   ├── IdentityController.cs  # Handles authentication (Register, Login, Logout, JWT)
│── Models/
│   ├── ApplicationDbContext.cs # Database context for Entity Framework
│── Repository/
│   ├── Interfaces/  # Contains repository interfaces
│   ├── UnitOfWork.cs # Handles transactions and database operations
│── ViewModels/
│   ├── RegisterViewModel.cs # View model for user registration
│   ├── LoginViewModel.cs # View model for user login
│── appsettings.json # Configuration file
│── Program.cs # Entry point of the application
│── Startup.cs # Configures services and middleware
```

---

## Installation & Setup

1. Clone the repository:
   ```sh
   git clone https://github.com/abdullahazmy/Template.git
   cd Template
   ```
2. Install dependencies:
   ```sh
   dotnet restore
   ```
3. Update `appsettings.json` with your database connection string.
4. Apply database migrations:
   ```sh
   dotnet ef database update
   ```
5. Run the application:
   ```sh
   dotnet run
   ```

---

## Configuration

Ensure that the `appsettings.json` file includes valid JWT settings:
```json
"JwtSettings": {
  "Key": "YourSuperSecretKey",
  "Issuer": "YourIssuer",
  "Audience": "YourAudience"
}
```

---

## Endpoints

### Authentication Endpoints
| Method | Route           | Description          |
|--------|---------------|----------------------|
| POST   | `/api/identity/register` | Register a new user |
| POST   | `/api/identity/login`    | Login and get a JWT token |
| POST   | `/api/identity/logout`   | Logout the current user |

---

## Code Explanation

### IdentityController.cs
This controller handles user authentication, including registration, login, logout, and JWT token generation.

#### **Register User**
```csharp
[HttpPost("register")]
public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
```
- Validates user input.
- Creates a new `IdentityUser`.
- Stores the user in the database.

#### **Login User**
```csharp
[HttpPost("login")]
public async Task<IActionResult> Login([FromBody] LoginViewModel model)
```
- Verifies credentials.
- Generates and returns a JWT token.

#### **Generate JWT Token**
```csharp
private string GenerateJwtToken(IdentityUser user)
```
- Creates a JWT token with user claims.
- Uses `JwtSecurityTokenHandler` to generate a signed token.

### ViewModels
View models define the data structure expected from the client.

#### RegisterViewModel.cs
```csharp
public class RegisterViewModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}
```
Defines the required fields for user registration.

#### LoginViewModel.cs
```csharp
public class LoginViewModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}
```
Defines the required fields for user login.

### Authentication Setup
Authentication is configured in `Startup.cs`:
```csharp
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:Key"]))
        };
    });
```
- Configures JWT authentication.
- Validates the token, issuer, and signing key.

---

## Swagger Integration
Swagger is added to document the API endpoints.

### **Setup in Startup.cs**
```csharp
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Template API", Version = "v1" });
});
```

### **Enable Swagger UI**
```csharp
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Template API V1");
});
```
- This allows API testing through an interactive interface at `/swagger`.

---

## Deployment Guide
Before deploying, follow these steps:

1. **Ensure Database Migrations are Applied**
   ```sh
   dotnet ef database update
   ```

2. **Set Environment Variables**
   ```sh
   export JwtSettings__Key="YourSuperSecretKey"
   export JwtSettings__Issuer="YourIssuer"
   export JwtSettings__Audience="YourAudience"
   ```

3. **Run in Production Mode**
   ```sh
   dotnet publish -c Release -o out
   cd out
   dotnet Template.dll
   ```

4. **Configure Hosting**
   - Use **IIS, Nginx, or Apache** for hosting.
   - Ensure **HTTPS** is enabled for security.

5. **Enable Logging & Monitoring**
   - Configure **Serilog** or **Application Insights** for logs.
   - Use **Prometheus/Grafana** for monitoring.

---

## License
This project is open-source and available under the MIT License.

