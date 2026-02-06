# Task Management API

ASP.NET Core REST API for managing tasks.

## Setup Instructions

### Prerequisites
- .NET 8 SDK

### Installation
1. Clone the repository
2. Navigate to project folder
3. Run: `dotnet restore`
4. Run: `dotnet ef database update`
5. Run: `dotnet run`

### Testing
- Swagger UI: https://localhost:5129/swagger
- Import Postman collection for testing

## Endpoints
- GET /api/tasks - List all tasks (filter by status: ?status=0)
- GET /api/tasks/{id} - Get single task
- POST /api/tasks - Create task
- PUT /api/tasks/{id} - Update task
- DELETE /api/tasks/{id} - Delete task

## Technology Stack
- ASP.NET Core 8
- Entity Framework Core
- SQLite