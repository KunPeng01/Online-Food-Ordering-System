using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.Data;
using OnlineFoodOrderingSystem.Models.Users.Admin;
using OnlineFoodOrderingSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register OnlineFoodOrderDbContext with SQLite
builder.Services.AddDbContext<OnlineFoodOrderDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register AppIdentityDbContext for Identity with SQLite
builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false; // Optional: make password rules less strict
})
.AddEntityFrameworkStores<AppIdentityDbContext>()
.AddDefaultTokenProviders();

// Configure Application Cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login"; // Redirect to Login page
    options.AccessDeniedPath = "/Account/AccessDenied"; // Redirect to Access Denied page
});

// Register services for dependency injection
builder.Services.AddScoped<IProductService, ProductService>();

// Enable session support
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Build the app
var app = builder.Build();

// Seed initial data for database and roles
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Seed the database
    DbInitializer.Seed(services);

    // Seed roles
    await RoleInitializer.SeedRolesAsync(services);
}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Adds HTTP Strict Transport Security
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
app.UseStaticFiles(); // Serve static files

app.UseRouting();

// Enable session middleware
app.UseSession();

// Enable authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

// Map controller routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the application
app.Run();
