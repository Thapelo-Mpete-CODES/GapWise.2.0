# GapWise 2.0

**An educational diagnostic platform designed to help identify learning gaps and support more targeted learning.**

GapWise is a web application project built with C# and ASP.NET Core MVC. Version 2.0 organises the application into dedicated components for request handling, application services, data transfer, middleware, and supporting resources.

This repository contains the application source code, test projects, database-related resources, documentation, and presentation materials.

## Project Demo

Explore GapWise 2.0 through the project presentation and application walkthrough.

- **Animated storyboard:** [View the PowerPoint presentation](presentation/GapWise_storyboard_animated.pptx)
- **Application walkthrough:** [Watch the GapWise demo video](presentation/Demo%20run.mp4)

## Application Screenshots

### Demo View

![GapWise demo view](https://github.com/user-attachments/assets/658c4391-17d3-4dab-9754-75b6b51a1d9b)

### Teacher Dashboard

![Teacher dashboard](https://github.com/user-attachments/assets/97acc9cf-8935-4716-b7c2-2219a7ae5884)

### Diagnostic Assessment

![Diagnostic assessment screen](https://github.com/user-attachments/assets/58282169-a4d0-44ea-9e46-9831352577f5)

### Learner Dashboard

![Learner dashboard](https://github.com/user-attachments/assets/5db6bf91-3ddb-4c0b-a0a1-a7447e17270d)

### Assessment Results

![Diagnostic test results](https://github.com/user-attachments/assets/975e9de4-7b08-4b8f-8d45-9831352577f5)

### Account Creation

![Account creation screen](https://github.com/user-attachments/assets/c1660d05-5fd1-4def-8c76-892a0b626882)



## Technology Stack

- **Language:** C#
- **Framework:** ASP.NET Core MVC
- **Platform:** .NET 9
- **Dependency management:** NuGet
- **Development environment:** Visual Studio

Refer to the project configuration and source code for the dependencies and integrations currently used by the application.

## Application Architecture

The web application uses a modular structure to separate responsibilities across different parts of the codebase.

| Component | Responsibility |
|---|---|
| Controllers | Handle incoming application requests |
| DTOs | Define data structures used to transfer information |
| Middleware | Supports request-processing behaviour |
| Interfaces | Define contracts between components |
| Services | Organise application logic and operations |

These components help make the codebase easier to navigate, maintain, and extend.

## Repository Structure

```text
GapWise.2.0/
├── assets/         # Project assets
├── database/       # Database-related resources
├── docs/           # Documentation
├── presentation/   # Project presentation materials
├── src/            # Application source code
├── tests/          # Test projects
├── GapWise.sln     # Visual Studio solution
├── NuGet.Config    # NuGet configuration
└── README.md
```

## Getting Started

### Prerequisites

- Visual Studio with the appropriate .NET development workload
- The .NET SDK required by the solution
- Any database or external services required by the application

### Open the project

1. Clone or download this repository.
2. Open `GapWise.sln` in Visual Studio.
3. Allow NuGet dependencies to restore.
4. Build the solution and resolve any environment-specific configuration requirements.
5. Select the web application as the startup project and run it.

Database configuration and other setup requirements should be checked against the current application configuration and project documentation.

## Project Status

GapWise 2.0 is an ongoing software development project. The repository provides the source code and supporting materials for reviewing its architecture and development work.

Refer to the demonstration video and the current implementation to evaluate the available functionality.

## Future Development

Potential areas for continued development include expanding automated test coverage, refining the user experience, and extending diagnostic reporting capabilities as required.

---

**Repository:** [GapWise.2.0 on GitHub](https://github.com/Thapelo-Mpete-CODES/GapWise.2.0)
