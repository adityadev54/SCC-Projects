using GoldenMenu.Data.DBContext;
using GoldenMenu.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Register a HttpClient
builder.Services.AddHttpClient();

// User Service
builder.Services.AddScoped<IUserService, UserService>();

// This Configures the Entity Framework Core
builder.Services.AddDbContext<GMDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .EnableSensitiveDataLogging()  // And this enables the sensitive data logging for debugging
           .LogTo(Console.WriteLine, LogLevel.Information));

// Register Authentication and Authorization Services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        // Re-direct to Login View if not authenticated
        options.LoginPath = "/User/Login";

        // Re-direct after logout
        options.LogoutPath = "/User/Logout";
        options.AccessDeniedPath = "/Home/AccessDenied";

        // Session Timeout
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });

builder.Services.AddAuthorization();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Login";
});


// Session Service
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// For PDF Downloads (License)
QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
