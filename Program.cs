using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderingSystem.Data;
using OnlineFoodOrderingSystem.Models.Users.Admin;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register ApplicationDbContext with Sql server
builder.Services.AddDbContext<OnlineFoodOrderDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register AppIdentityDbContext with Sql server
builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(opts =>
{
    opts.User.RequireUniqueEmail = true;
    opts.Password.RequiredLength = 8;
    opts.Password.RequireLowercase = true;
});


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login"; 
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Login}/{id?}");

app.Run();
