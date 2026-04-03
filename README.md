# FoodPanda Identity

A food delivery web application built with ASP.NET Core, featuring user authentication, role-based authorization, and real-time ordering capabilities.

## Features

- **User Authentication & Authorization**: Built-in ASP.NET Core Identity with role-based access control
- **Food Categories**: Browse food by categories (Fast Food, Breakfast, Desi Food)
- **Shopping Cart**: Add items to cart and manage orders
- **Real-time Updates**: SignalR integration for live notifications
- **Admin Panel**: Administrative features for managing the application
- **Responsive Design**: Modern web interface with MVC architecture

## Technologies Used

- **Framework**: ASP.NET Core 8.0
- **Database**: SQL Server (LocalDB for development)
- **ORM**: Entity Framework Core
- **Authentication**: ASP.NET Core Identity
- **Real-time Communication**: SignalR
- **Frontend**: Razor Views with Bootstrap/CSS
- **Architecture**: MVC (Model-View-Controller)

## Prerequisites

- .NET 8.0 SDK
- SQL Server (LocalDB included with Visual Studio)
- Visual Studio 2022 or VS Code with C# extensions

## Getting Started

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd dotnet
   ```

2. **Restore packages**
   ```bash
   dotnet restore
   ```

3. **Update database**
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Open your browser** and navigate to `https://localhost:5001`

## Project Structure

```
FoodPandaIdentity/
├── Controllers/          # MVC Controllers
│   ├── HomeController.cs
│   ├── FoodController.cs
│   ├── AdminController.cs
│   └── CustomerController.cs
├── Models/              # Data Models and Interfaces
│   ├── Product.cs
│   ├── ApplicationUser.cs
│   ├── CartItems.cs
│   └── Interfaces/
├── Views/               # Razor Views
├── Areas/               # Identity UI Area
├── Data/                # Database Context
├── Hubs/                # SignalR Hubs
├── Migrations/          # EF Core Migrations
└── Properties/          # Launch Settings
```

## Configuration

The application uses the following configuration files:

- `appsettings.json`: Main configuration
- `appsettings.Development.json`: Development-specific settings

Database connection string is configured in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=FoodPandaIdentity;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

## User Roles

- **Admin**: Full access to administrative features
- **User**: Standard user with ordering capabilities

## API Endpoints

The application includes several controllers:

- `/Home`: Landing page and general navigation
- `/Food`: Food browsing and ordering (requires User role)
- `/Admin`: Administrative functions (requires Admin role)
- `/Identity`: Authentication and user management

## Development

### Adding New Features

1. Create models in the `Models` folder
2. Add controllers in the `Controllers` folder
3. Create corresponding views in the `Views` folder
4. Update database migrations if needed

### Database Migrations

```bash
# Add new migration
dotnet ef migrations add MigrationName

# Update database
dotnet ef database update
```

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Support

For support and questions, please open an issue in the repository.</content>
<parameter name="filePath">c:\Users\ibrah\OneDrive\Desktop\dotnet\README.md
