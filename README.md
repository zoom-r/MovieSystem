# MovieSystem API

A full-stack, enterprise-grade movie management system built with **ASP.NET Core** and **C#**, strictly adhering to **Clean Architecture** principles.

## Architecture Overview

The solution is decoupled into distinct architectural layers to maximize maintainability, testability, and separation of concerns:

- **Domain Layer:** Core enterprise entities, enumerations, and repository interfaces.
- **Application Layer:** Business logic orchestration, Data Transfer Objects (DTOs), AutoMapper mapping profiles, and FluentValidation validators.
- **Infrastructure Layer:** Database context, Entity Framework Core configurations, database migrations, and external service implementations.
- **API (Presentation) Layer:** RESTful API endpoints, request routing, exception-handling middleware, and Swagger documentation.

## Tech Stack & Key Libraries

- **Framework:** .NET 8 / ASP.NET Core Web API
- **Data Access:** Entity Framework Core (Code-First), Relational Database (SQL Server / MySQL)
- **Mapping & Validation:** AutoMapper, FluentValidation
- **Testing & Tooling:** Swagger / OpenAPI, Postman, Git

## Key Features

- **RESTful Endpoints:** Full CRUD operations for movies, genres, and related domain entities.
- **Robust Validation Pipeline:** Automatic payload validation using FluentValidation before reaching controllers.
- **Data Encapsulation:** Safe data transfer using incoming/outgoing DTOs.
- **Database Migrations:** Version-controlled database schema changes via EF Core CLI.
