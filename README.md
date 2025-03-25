# Unit of Work API Project

A .NET Core MVC 9 API project implementing the Unit of Work pattern with Entity Framework Core for efficient data access and management.

## Project Overview

This API project demonstrates the implementation of the Unit of Work pattern along with Repository pattern for better separation of concerns and maintainable code structure. The project uses SQL Server as the database and includes Swagger/OpenAPI documentation.

## Technologies Used

- .NET Core MVC 9
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI
- Unit of Work Pattern
- Repository Pattern

## Project Structure

```
UnitOfWorkAPI/
├── UnitOfWorkAPI/                 # Main API Project
│   ├── Controllers/              # API Controllers
│   ├── Models/                   # View Models and DTOs
│   └── appsettings.json         # Configuration settings
├── UnitOfWorkAPI.DataAccess/     # Data Access Layer
│   ├── Context/                  # Database Context
│   ├── Repositories/            # Repository implementations
│   └── UnitOfWork/              # Unit of Work implementation
└── UnitOfWorkAPI.Domain/        # Domain Layer
    ├── Entities/                # Domain entities
    └── Interfaces/              # Repository interfaces
```

## Database Schema

### Product Table
```sql
CREATE TABLE [dbo].[Product](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [BrandId] [int] NOT NULL,
    [Sku] [nvarchar](50) NOT NULL,
    [Name] [nvarchar](150) NOT NULL,
    [Description] [nvarchar](500) NULL,
    [Barcode] [nvarchar](50) NOT NULL,
    [Price] [float] NOT NULL,
    [CreatedDate] [datetime] NOT NULL,
    [Status] [bit] NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
)
```

### Brand Table
```sql
CREATE TABLE [dbo].[Brand](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](50) NOT NULL,
    CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED ([Id] ASC)
)
```

## Getting Started

### Prerequisites

- .NET Core SDK 9.0 or later
- SQL Server
- Visual Studio 2022 or later

### Configuration

1. Clone the repository
2. Update the connection string in `appsettings.json` with your SQL Server details
3. Run the database migrations
4. Build and run the project

### Running the Application

1. Navigate to the project directory
2. Run the following commands:
```bash
dotnet restore
dotnet build
dotnet run
```

3. Access the Scalar V1 UI at: `https://localhost:7132/scalar/`

## Features

- RESTful API endpoints for Product and Brand management
- Unit of Work pattern implementation for transaction management
- Repository pattern for data access abstraction
- Swagger/OpenAPI documentation
- Entity Framework Core for database operations
- Clean architecture principles

## API Endpoints

The API provides endpoints for:

- Products
  - GET /api/products
  - GET /api/products/{id}
  - POST /api/products
  - PUT /api/products/{id}
  - DELETE /api/products/{id}

- Brands
  - GET /api/brands
  - GET /api/brands/{id}
  - POST /api/brands
  - PUT /api/brands/{id}
  - DELETE /api/brands/{id}

## License

This project is licensed under the MIT License. 