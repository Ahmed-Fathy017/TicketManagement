# Ticket Management System

A modern, full-stack ticket management application built with .NET 8 and Angular 20, featuring real-time updates using SignalR.

## 🏗️ Architecture

This project follows Clean Architecture principles with the following layers:

```
TicketManagement/
├── TicketManagement.Domain/          # Core business logic and entities
├── TicketManagement.Application/     # Application services and CQRS
├── TicketManagement.Infrastructure/  # Data access and external services
├── TicketManagement.WebApi/          # REST API and SignalR hub
├── TicketManagement.WebApp/          # Angular frontend application
└── TicketManagement.Tests/           # Unit and integration tests
```

### Technology Stack

**Backend:**
- .NET 8
- Entity Framework Core 8.0.18
- SQL Server
- MediatR (CQRS pattern)
- SignalR (real-time communication)
- Swagger/OpenAPI

**Frontend:**
- Angular 20.1.0
- TypeScript 5.8.2
- SignalR Client (@microsoft/signalr)
- RxJS 7.8.0

## 🚀 Features

### Core Functionality
- **Ticket Creation**: Create tickets with phone number, governorate, city, and district
- **Ticket Listing**: Paginated list with search and filtering
- **Ticket Management**: Mark tickets as handled
- **Real-time Updates**: Live updates using SignalR when tickets are created or modified

### UI/UX Features
- **Responsive Design**: Modern, minimalist interface
- **Time-based Priority**: Color-coded status based on ticket age
- **Modal Forms**: Clean ticket creation interface
- **Pagination**: Efficient data loading
- **Real-time Notifications**: Instant updates without page refresh

### Technical Features
- **CQRS Pattern**: Command Query Responsibility Segregation
- **Clean Architecture**: Separation of concerns
- **Dependency Injection**: Proper service registration
- **Error Handling**: Comprehensive error management
- **CORS Configuration**: Secure cross-origin requests
- **Centralized Configuration**: Environment-based settings

## 📋 Prerequisites

Before running this application, ensure you have the following installed:

- **.NET 8 SDK** - [Download here](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Node.js 18+** - [Download here](https://nodejs.org/)
- **SQL Server** (LocalDB, Express, or Developer Edition)
- **Angular CLI** - Install with `npm install -g @angular/cli`

## 🛠️ Setup Instructions

### 1. Database Setup

1. **Install SQL Server** (if not already installed)
   - Download SQL Server Express or use LocalDB
   - Ensure SQL Server is running

2. **Update Connection String**
   - Open `TicketManagement.WebApi/appsettings.json`
   - Update the connection string to match your SQL Server instance:
   ```json
   "ConnectionStrings": {
     "TicketManagement": "Server=.; Initial Catalog=TicketManagementDB; User ID=sa; Password=123@qwe; TrustServerCertificate=true;"
   }
   ```

3. **Run Database Migrations**
   ```bash
   cd TicketManagement.WebApi
   dotnet ef database update
   ```

### 2. Backend Setup

1. **Restore NuGet Packages**
   ```bash
   dotnet restore
   ```

2. **Build the Solution**
   ```bash
   dotnet build
   ```

3. **Run the Web API**
   ```bash
   cd TicketManagement.WebApi
   dotnet run
   ```
   
   The API will be available at:
   - **API**: https://localhost:44308
   - **Swagger UI**: https://localhost:44308/swagger

### 3. Frontend Setup

1. **Install Dependencies**
   ```bash
   cd TicketManagement.WebApp
   npm install
   ```

2. **Start the Angular Application**
   ```bash
   npm start
   ```
   
   The frontend will be available at: http://127.0.0.1:4200

### 4. Verify Installation

1. **Check API Health**: Visit https://localhost:44308/swagger
2. **Check Frontend**: Visit http://127.0.0.1:4200
3. **Test Real-time Features**: Create a ticket and observe real-time updates

## 🔧 Configuration

### Backend Configuration

The main configuration file is `TicketManagement.WebApi/appsettings.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Cors": {
    "AllowedOrigins": [ "https://localhost:4200", "http://localhost:60020" ]
  },
  "ConnectionStrings": {
    "TicketManagement": "Server=.; Initial Catalog=TicketManagementDB; User ID=sa; Password=123@qwe; TrustServerCertificate=true;"
  }
}
```

### Frontend Configuration

Configuration is centralized in `TicketManagement.WebApp/src/app/services/config.service.ts`:

```typescript
private environment: Environment = {
  production: false,
  apiBaseUrl: 'https://localhost:44308',
  signalRHubUrl: 'https://localhost:44308/hubs/dataChange',
  apiEndpoints: {
    tickets: '/api/tickets'
  }
};
```

## 📚 API Documentation

### Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/tickets` | Create a new ticket |
| GET | `/api/tickets` | Get paginated list of tickets |
| PATCH | `/api/tickets/{id}` | Mark ticket as handled |

### SignalR Hub

- **Hub URL**: `/hubs/dataChange`
- **Events**: `TicketCreated`, `TicketUpdated`

## 🧪 Testing

### Run Backend Tests
```bash
cd TicketManagement.Tests
dotnet test
```

### Run Frontend Tests
```bash
cd TicketManagement.WebApp
npm test
```

## 🏃‍♂️ Usage

### Creating a Ticket
1. Click the "+" button in the top-right corner
2. Fill in the required fields:
   - Phone Number
   - Governorate
   - City
   - District
3. Click "Create Ticket"

### Managing Tickets
1. View all tickets in the main list
2. Tickets are color-coded by priority:
   - **White**: New (0-15 minutes)
   - **Yellow**: Low Priority (15-30 minutes)
   - **Green**: Medium Priority (30-45 minutes)
   - **Blue**: Urgent (45-60 minutes)
   - **Red**: 60+ minutes
3. Click "Mark as Handled" to resolve tickets
4. Real-time updates will appear automatically

## 🔍 Project Structure

### Backend Structure

```
TicketManagement.Application/
├── Commands/              # CQRS Commands
│   ├── CreateTicketCommand.cs
│   └── MarkTicketAsHandledCommand.cs
├── Queries/               # CQRS Queries
│   └── GetTicketsPaginatedListQuery.cs
├── DTOs/                  # Data Transfer Objects
├── Services/              # Application Services
└── Interfaces/            # Service Contracts

TicketManagement.Domain/
├── Entities/              # Domain Entities
│   └── Tickets/
├── Repositories/          # Repository Interfaces
└── Common/                # Shared Domain Models

TicketManagement.Infrastructure/
├── Repositories/          # Repository Implementations
├── Configurations/        # EF Core Configurations
├── Migrations/            # Database Migrations
└── TicketManagementDbContext.cs

TicketManagement.WebApi/
├── Controllers/           # API Controllers
├── Hubs/                  # SignalR Hubs
├── Extensions/            # Service Registration
└── Common/                # Shared API Components
```

### Frontend Structure

```
TicketManagement.WebApp/src/app/
├── components/            # Angular Components
│   ├── ticket-list/       # Ticket listing component
│   └── ticket-create/     # Ticket creation modal
├── services/              # Angular Services
│   ├── ticket.service.ts  # API communication
│   ├── signal-r-service.ts # Real-time updates
│   └── config.service.ts  # Configuration management
├── models/                # TypeScript Interfaces
└── app-routing-module.ts  # Routing configuration
```

## 🚨 Troubleshooting

### Common Issues

1. **Database Connection Error**
   - Verify SQL Server is running
   - Check connection string in `appsettings.json`
   - Ensure database exists and migrations are applied

2. **CORS Errors**
   - Verify CORS configuration in `appsettings.json`
   - Check that frontend URL is in allowed origins

3. **SignalR Connection Issues**
   - Ensure CORS is configured before SignalR
   - Check browser console for connection errors
   - Verify hub URL in frontend configuration

4. **Angular Build Errors**
   - Clear node_modules and reinstall: `rm -rf node_modules && npm install`
   - Update Angular CLI: `npm install -g @angular/cli@latest`

### Development Tips

- Use Swagger UI for API testing: https://localhost:44308/swagger
- Check browser developer tools for frontend debugging
- Monitor SignalR connections in browser console
- Use Entity Framework migrations for database changes

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests for new functionality
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License.

## 📞 Support

For support and questions, please open an issue in the repository.