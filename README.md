# 🎬 eTickets — ASP.NET Core MVC Movie Ticket Booking Platform

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![EF Core](https://img.shields.io/badge/EF_Core-8.0-512BD4?style=for-the-badge&logo=entityframeworkcore&logoColor=white)](https://learn.microsoft.com/ef/core/)
[![SQL Server](https://img.shields.io/badge/SQL_Server-2022-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server)
[![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)](https://getbootstrap.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](https://opensource.org/licenses/MIT)

---

## 📖 Overview

**eTickets** is a full-featured, production-ready **ASP.NET Core MVC** web application simulating an online movie ticket booking system. It demonstrates modern .NET architecture patterns including **Clean Architecture principles**, **Repository & Service Layers**, **Entity Framework Core Code-First Migrations**, **Identity Authentication & Authorization**, and **Session-based Shopping Cart** management.

Built as a comprehensive reference implementation, it covers the complete software development lifecycle: from domain modeling and database seeding to responsive UI rendering and role-based access control.

---

## ✨ Key Features

### 🎭 Core Domain Management (CRUD)
| Entity | Features |
| :--- | :--- |
| **Movies** | Full lifecycle management; Poster upload; Genre classification; Many-to-Many relationship with Actors. |
| **Cinemas** | Location & branding management; Logo upload; One-to-Many with Movies. |
| **Actors** | Profile management (Bio, DOB, Photo); Many-to-Many relationship with Movies via `Actor_Movie` join entity. |
| **Producers** | Studio/Company management; Logo upload; One-to-Many with Movies. |

### 🛒 E-Commerce & Orders
- **Session-Based Shopping Cart**: Persistent cart state across requests using `ISession` and a dedicated `ShoppingCart` service.
- **ViewComponent**: Real-time `ShoppingCartSummary` in the Navigation Bar displaying item count.
- **Order Processing**: Checkout flow converting cart items to `Order` & `OrderItem` entities; Transactional integrity via EF Core.
- **Order History**: Authenticated users can view past purchases.

### 🔐 Security & Identity
- **ASP.NET Core Identity**: Integrated `ApplicationUser` extending `IdentityUser`.
- **Role-Based Authorization**: Seeded roles (`Admin`, `User`) via `UserRoles.cs` and `DBInitializer`.
- **Policy Enforcement**: `[Authorize(Roles = "Admin")]` on all Create/Edit/Delete actions.
- **Secure Password Hashing**: PBKDF2 with HMAC-SHA256 (Identity Default).

### 🏗️ Architecture & Code Quality
- **Generic Repository Pattern**: `IEntityBaseRepository<T>` / `EntityBaseRepository<T>` reduces boilerplate for CRUD.
- **Service Layer Abstraction**: Business logic encapsulated in Services (`IMovieService`, `IOrderService`, etc.) injected into Controllers.
- **Dependency Injection**: Native .NET DI container configured in `Program.cs`.
- **Database Seeding**: `DBInitializer` & `DBInitializerExtension` populate roles, users, and sample catalog data on startup.
- **ViewModels & Tuples**: Complex view data (e.g., `Movie` dropdowns for Actors/Cinemas/Producers) passed via `Tuple` or specific ViewModels.

---

## 🛠️ Tech Stack

| Category | Technology | Usage |
| :--- | :--- | :--- |
| **Runtime** | **.NET 8.0** (LTS) | Target Framework (`eTickets.csproj`) |
| **Web Framework** | **ASP.NET Core MVC** | Controllers, Views, Razor Pages, Middleware |
| **ORM** | **Entity Framework Core 8.0** | Code-First Migrations, LINQ, Change Tracking |
| **Database** | **Microsoft SQL Server** | LocalDB / Express / Azure SQL (Connection String in `appsettings.json`) |
| **Auth** | **ASP.NET Core Identity** | Authentication, Authorization, User Management |
| **Frontend** | **Bootstrap 5.3**, **jQuery 3.x**, **jQuery Validation** | Responsive UI, Client-side validation, Unobtrusive AJAX |
| **Templating** | **Razor View Engine** | Server-side rendering (`Views/` folder) |
| **Build Tool** | **MSBuild / .NET CLI** | `dotnet build`, `dotnet run`, `dotnet ef` |
| **Version Control** | **Git** | Standard `.gitignore` for .NET (bin, obj, .vs, Migrations optional) |

---

## 🏛️ Architecture Overview

```text
eTickets.sln
│
├── eTickets (Main Project)
│   ├── Controllers/           # MVC Controllers (Thin: delegate to Services)
│   │   ├── MovieController.cs
│   │   ├── CinemaController.cs
│   │   ├── ActorController.cs
│   │   └── ProducerController.cs
│   │
│   ├── Data/
│   │   ├── eTicketsDbContext.cs      # EF Core DbContext (DbSets, Config)
│   │   ├── DBInitializer.cs          # Seeding Logic (Roles, Users, Data)
│   │   ├── DBInitializerExtension.cs # Extension method for Program.cs
│   │   │
│   │   ├── Base/                     # Generic Repository Infrastructure
│   │   │   ├── IEntityBase.cs
│   │   │   ├── IEntityBaseRepository.cs
│   │   │   └── EntityBaseRepository.cs
│   │   │
│   │   ├── Services/                 # Business Logic Layer (Interfaces + Impl)
│   │   │   ├── ICinemaService.cs / CinemaService.cs
│   │   │   ├── IActorsService.cs / ActorsService.cs
│   │   │   ├── IProducerService.cs / ProducerService.cs
│   │   │   └── IOrderService.cs / OrderService.cs
│   │   │
│   │   ├── Cart/ShoppingCart.cs      # Session Wrapper Service
│   │   ├── Enums/Genre.cs
│   │   ├── Static/UserRoles.cs
│   │   └── ViewComponents/ShoppingCartSummary.cs # Navbar Cart Count
│   │
│   ├── Models/                       # Domain Entities (POCOs)
│   │   ├── Movie.cs, Cinema.cs, Actor.cs, Producer.cs
│   │   ├── Actor_Movie.cs            # Many-to-Many Join Entity
│   │   ├── Order.cs, OrderItem.cs
│   │   ├── ShoppingCartItem.cs
│   │   └── ApplicationUser.cs        # Identity Extension
│   │
│   ├── Views/                        # Razor Views (Feature Folders)
│   │   ├── Movie/, Cinema/, Actor/, Producer/ (Index, Create, Edit, Details, Delete)
│   │   ├── Shared/ (_Layout.cshtml, _ValidationScriptsPartial, Error, NotFound)
│   │   └── _ViewImports.cshtml, _ViewStart.cshtml
│   │
│   ├── wwwroot/                      # Static Assets
│   │   ├── css/site.css
│   │   ├── lib/bootstrap/, jquery/, jquery-validation/
│   │   └── images/ (Implicit for uploads)
│   │
│   ├── Migrations/                   # EF Core History & Snapshots
│   ├── Program.cs                    # App Entry Point, DI Config, Middleware Pipeline
│   ├── appsettings.json              # Configuration (Conn Strings, Identity)
│   └── eTickets.csproj               # Project SDK, Package References
│
└── Properties/launchSettings.json    # Debug Profiles (IIS Express, Kestrel)
```

---

## 🚀 Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (or version matching `TargetFramework` in `.csproj`)
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (LocalDB, Express, Developer Edition, or Docker)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) (with **ASP.NET and web development** workload) **OR** [VS Code](https://code.visualstudio.com/) + [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
- Git

### Installation & Setup

1.  **Clone the Repository**
    ```bash
    git clone https://github.com/your-username/eTickets.git
    cd eTickets
    ```

2.  **Configure Database Connection**
    Open `appsettings.json` (or `appsettings.Development.json` for local overrides) and update the `DefaultConnection` string.
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=eTicketsDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
    }
    ```
    *Note: `TrustServerCertificate=True` is required for LocalDB/Dev certs.*

3.  **Restore Dependencies & Build**
    ```bash
    dotnet restore
    dotnet build
    ```

4.  **Apply Database Migrations (Code-First)**
    This creates the database schema and runs the `DBInitializer` seed data.
    ```bash
    # Option A: .NET CLI (Cross-platform)
    dotnet ef database update --project eTickets

    # Option B: Package Manager Console (Visual Studio)
    # Update-Database
    ```

5.  **Run the Application**
    ```bash
    dotnet run --project eTickets
    ```
    Navigate to `https://localhost:5001` (or port shown in console/launchSettings.json).

---

## 👤 Default Login Credentials (Seeded)

The `DBInitializer` creates default users on first run.

| Role | Email | Password | Access Level |
| :--- | :--- | :--- | :--- |
| **Administrator** | `admin@etickets.com` | `Admin@123` | Full CRUD on Movies, Cinemas, Actors, Producers; View All Orders. |
| **Standard User** | `user@etickets.com` | `User@123` | Browse Movies, Add to Cart, Checkout, View Own Order History. |

> **Security Note**: Change these passwords immediately in a production environment. Enforce HTTPS and strong password policies via `Program.cs` Identity configuration.

---

## 📂 Project Structure Deep Dive

### 1. Domain Models (`Models/`)
Rich domain entities with Data Annotations for validation and EF Core mapping.
- **Relationships**: Fluent API in `eTicketsDbContext.OnModelCreating` configures:
  - `Movie` 1:N `Cinema`
  - `Movie` 1:N `Producer`
  - `Movie` N:M `Actor` (via `Actor_Movie` join entity with payload).
  - `Order` 1:N `OrderItem`
  - `ShoppingCart` 1:N `ShoppingCartItem` (Ephemeral, Session-backed).

### 2. Data Access (`Data/`)
- **`IEntityBaseRepository<T>`**: Generic `GetAllAsync`, `GetByIdAsync`, `AddAsync`, `UpdateAsync`, `DeleteAsync`, `GetAllAsync(params Expression<Func<T, object>>[] includes)`.
- **Services**: Concrete implementations (`CinemaService`, `ActorsService`) inject `IEntityBaseRepository<T>` and `AppDbContext` for complex queries (e.g., `GetMovieByIdAsync` with Includes for Actors/Cinema/Producer).

### 3. Shopping Cart (`Data/Cart/ShoppingCart.cs`)
- **Scoped Lifetime**: Registered as `AddScoped` in `Program.cs`.
- **Session Serialization**: Uses `System.Text.Json` to serialize `List<ShoppingCartItem>` to `ISession`.
- **ViewComponent**: `ShoppingCartSummary` invoked in `_Layout.cshtml`:
  ```razor
  @await Component.InvokeAsync("ShoppingCartSummary")
  ```

### 4. UI Layer (`Views/`)
- **Shared Layout**: `_Layout.cshtml` includes Bootstrap 5 Navbar, Partial for `_LoginPartial` (Identity), and `ShoppingCartSummary`.
- **CRUD Views**: Standard scaffolded Razor views with `asp-action`, `asp-controller`, `asp-route-id` tag helpers.
- **Validation**: `_ValidationScriptsPartial.cshtml` included in Create/Edit forms for client-side jQuery Unobtrusive Validation.

---

## ⚙️ Configuration Details

### `Program.cs` Highlights
```csharp
// 1. DbContext & SQL Server
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Identity Configuration
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// 3. Password Policy (Example)
builder.Services.Configure<IdentityOptions>(options => {
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;
});

// 4. DI Registration: Repositories, Services, Cart, ViewComponents
builder.Services.AddScoped<IEntityBaseRepository<Movie>, EntityBaseRepository<Movie>>();
builder.Services.AddScoped<IMovieService, MovieService>(); // Custom logic
builder.Services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession(); // Required for Cart

// 5. Middleware Pipeline
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();       // Before Auth
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Movie}/{action=Index}/{id?}");

// 6. Database Seeding
AppDbInitializer.Seed(app); // Extension method calling DBInitializer.SeedUsersAndRolesAsync + SeedData
```

---

## 🧪 Testing the Features

1.  **Anonymous User**: Browse Movies (`/Movie/Index`), View Details. Cart icon shows `0`.
2.  **Register / Login**: Click "Register" (Identity UI) or use seeded credentials.
3.  **Add to Cart**: On Movie Details, select quantity -> "Add to Cart". Navbar count updates instantly (ViewComponent).
4.  **Checkout**: Navigate to Cart (`/ShoppingCart/Index`) -> "Checkout". Creates `Order` record, clears Session Cart.
5.  **Admin Dashboard**: Login as Admin -> Access "Producers", "Cinemas", "Actors" nav links (hidden from Users via `_Layout` role check).
6.  **Admin CRUD**: Create a new Cinema with Logo upload -> Verify appearance in Movie Create Dropdown.

---

## 📦 Deployment Considerations

1.  **Environment Variables**: Use `ASPNETCORE_ENVIRONMENT=Production`. Store Connection Strings & Secrets in **Azure Key Vault**, **AWS Secrets Manager**, or **User Secrets** (dev only).
2.  **HTTPS**: Enforce `app.UseHsts()` and `app.UseHttpsRedirection()` in Production.
3.  **Static Files**: Configure CDN/Blob Storage for `wwwroot` and **User Uploaded Images** (Movie Posters, Actor Photos). Current implementation saves to `wwwroot/images` (ephemeral on container restart).
4.  **EF Migrations**: Run `dotnet ef database update` as part of CI/CD pipeline **OR** use `context.Database.Migrate()` in `Program.cs` startup (with caution).
5.  **Docker**: Multi-stage `Dockerfile` (SDK -> Runtime) recommended. Expose port 8080/80.

---

## 🤝 Contributing

Contributions are welcome! Please follow the standard GitHub Flow:
1.  Fork the repository.
2.  Create a feature branch (`git checkout -b feature/AmazingFeature`).
3.  Commit changes (`git commit -m 'Add AmazingFeature'`).
4.  Push to branch (`git push origin feature/AmazingFeature`).
5.  Open a **Pull Request**.

**Coding Standards**:
- Follow **Microsoft C# Coding Conventions**.
- Use `async/await` for all I/O operations.
- Keep Controllers thin; push logic to Services.
- Write Unit Tests for Services (xUnit + Moq) and Integration Tests for Controllers (WebApplicationFactory).

---

## 📄 License

Distributed under the **MIT License**. See `LICENSE.txt` for more information.

---

## 🙏 Acknowledgements

- [Microsoft ASP.NET Core Documentation](https://learn.microsoft.com/aspnet/core/)
- [Entity Framework Core Docs](https://learn.microsoft.com/ef/core/)
- [Bootstrap](https://getbootstrap.com/) & [jQuery](https://jquery.com/) Teams
- Community contributors and tutorial authors inspiring this architecture.

---

> **Built with ❤️ using .NET 8 and ASP.NET Core MVC.**  
> *If you found this helpful, please consider giving a ⭐ on GitHub!*