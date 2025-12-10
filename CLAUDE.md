# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build and Run Commands

```bash
# Build the solution
dotnet build

# Run the application
dotnet run --project TasksToGo

# Run with hot reload
dotnet watch --project TasksToGo

# Entity Framework migrations
dotnet ef migrations add <MigrationName> --project TasksToGo
dotnet ef database update --project TasksToGo
```

**Development URLs:**
- HTTP: http://localhost:5190
- HTTPS: https://localhost:7126

## Architecture Overview

This is an ASP.NET Core 8.0 MVC application for task management with SQL Server backend.

### Project Structure

- **TasksToGo/** - Main web application
  - **Models/** - Domain entities (`TodoTask`, `TaskCategory`)
  - **Controllers/** - MVC controllers handling HTTP requests
  - **Views/** - Razor views organized by controller
  - **Context/** - `ApplicationDbContext` for Entity Framework Core
  - **Configurations/** - Fluent API entity configurations
  - **Migrations/** - EF Core database migrations

### Data Access Pattern

- Entity Framework Core with direct DbContext injection into controllers
- No repository/service abstraction layer
- Fluent API configurations in `/Configurations/` define constraints and relationships

### Database

SQL Server database `taskstogo` with two tables:
- **TaskCategories** - Categories for organizing tasks
- **todoTasks** - Individual task items with foreign key to categories

Connection string is in `appsettings.json` under `ConnectionStrings:DefaultConn`.

### Key Relationships

- TaskCategory has many TodoTask (one-to-many)
- Cascade delete enabled on category deletion
