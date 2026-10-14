# GapWise

GapWise is an ASP.NET Core MVC startup product foundation for identifying, organizing, and acting on gaps in a structured workflow. This repository contains the initial MVP solution structure only.

## Vision

GapWise should become a focused, professional platform that helps users move from unclear gaps to practical next steps with speed, clarity, and confidence.

## MVP Goal

The MVP goal is to establish a clean, maintainable .NET 9 web application foundation that can support rapid feature development during a 10-day competition. This foundation intentionally avoids application features, authentication scaffolding, database schema creation, and sample business logic.

## Technology Stack

- .NET 9
- ASP.NET Core MVC
- Entity Framework Core with SQL Server, planned but not configured yet
- ASP.NET Identity, planned but not configured yet
- SQL Server, planned but no database created yet
- Bootstrap 5, planned for the web UI
- AutoMapper, planned for object mapping
- FluentValidation, planned for input validation

## Folder Structure

```text
GapWise/
├── src/
│   └── GapWise.Web/
│       ├── Controllers/
│       ├── Models/
│       ├── Data/
│       ├── Services/
│       ├── Interfaces/
│       ├── Repositories/
│       ├── DTOs/
│       ├── ViewModels/
│       ├── Helpers/
│       ├── Extensions/
│       ├── Mappings/
│       ├── Middleware/
│       ├── Views/
│       └── wwwroot/
│           ├── css/
│           ├── js/
│           ├── images/
│           └── uploads/
├── docs/
├── database/
├── assets/
├── presentation/
├── tests/
├── .gitignore
├── README.md
├── NuGet.Config
└── GapWise.sln
```

## Development Standards

- Keep the web project focused on ASP.NET Core MVC responsibilities.
- Keep `Program.cs` minimal and move future registrations into extension methods.
- Enable nullable reference types and implicit usings for modern C# defaults.
- Add packages only when the corresponding capability is actually implemented.
- Avoid sample business logic, throwaway demo pages, and premature abstractions.
- Prefer small, testable services and explicit interfaces when features begin.
- Keep database migrations and schema changes intentional and reviewable.

## Recommended NuGet Packages

These packages are recommended when their corresponding capabilities are introduced:

| Purpose | Package |
| --- | --- |
| ASP.NET Core MVC | Included through `Microsoft.NET.Sdk.Web` and the shared ASP.NET Core framework |
| EF Core SQL Server | `Microsoft.EntityFrameworkCore.SqlServer` |
| EF Core tooling | `Microsoft.EntityFrameworkCore.Tools` |
| ASP.NET Identity with EF Core | `Microsoft.AspNetCore.Identity.EntityFrameworkCore` |
| AutoMapper integration | `AutoMapper.Extensions.Microsoft.DependencyInjection` |
| FluentValidation MVC integration | `FluentValidation.AspNetCore` |

## Build

```powershell
dotnet build GapWise.sln --configfile NuGet.Config
```
