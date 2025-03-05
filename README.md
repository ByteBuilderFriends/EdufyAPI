# EdufyAPI

## Overview
EdufyAPI is the backend service for the Edufy platform, a modern educational system designed to facilitate seamless interaction between students and instructors. The API provides functionalities for user authentication, course management, payments, and more.

## Features
- ✅ User authentication (Student & Instructor)
- 📚 Course creation and enrollment
- 🔒 API rate limiting and security measures
- 🛡️ Role-based access control

## Technologies Used
- **🖥 Programming Language:** C#
- **🛠 Framework:** .NET Core
- **🗄 Database:** SQL Server / PostgreSQL
- **🔑 Authentication:** JWT
- **📦 Deployment:** Docker, Kubernetes (Optional)
- **📌 Version Control:** Git & GitHub

## Getting Started
### Prerequisites
Ensure you have the following installed:
- .NET SDK (latest version)
- SQL Server / PostgreSQL
- Docker (if containerization is used)
- Git

### Installation
1. **Clone the repository:**
   ```bash
   git clone https://github.com/abdullahazmy/EdufyAPI.git
   cd EdufyAPI
   ```
2. **Restore dependencies:**
   ```bash
   dotnet restore
   ```
3. **Set up the database:**
   - Configure your database connection string in `appsettings.json`
   - Apply migrations:
     ```bash
     dotnet ef database update
     ```
4. **Run the API:**
   ```bash
   dotnet run
   ```

### API Documentation
API documentation is available using Swagger.
- Start the application and navigate to:
  ```
  http://localhost:5000/swagger
  ```

## Project Structure
```
EdufyAPI/
│── Controllers/
│── Models/
│── Services/
│── Repositories/
│── Migrations/
│── appsettings.json
│── Program.cs
│── Startup.cs
│── README.md
```

## Contributing
🚀 Contributions are welcome! Please follow these steps:
1. **Fork** the repository
2. **Create** a new branch (`feature-branch`)
3. **Commit** your changes
4. **Push** the branch and create a **Pull Request**

## License
📜 EdufyAPI is licensed under the **MIT License**.

