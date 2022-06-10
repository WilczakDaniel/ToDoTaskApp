using System.Reflection;
using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ToDoTaskApp;
using ToDoTaskApp.Database;
using ToDoTaskApp.Entities;
using ToDoTaskApp.Middleware;
using ToDoTaskApp.Models;
using ToDoTaskApp.Models.Validator;
using ToDoTaskApp.Services;
using ToDoTaskApp.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add database connection
builder.Services.AddDbContext<AppDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("Application")));

// Add authorization
var authSettings = new AuthSettings();
builder.Configuration.GetSection("Authentication").Bind(authSettings);
builder.Services.AddSingleton(authSettings);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authSettings.JwtIssuer,
        ValidAudience = authSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.JwtKey)),
    };
});

// Add UserService
builder.Services.AddScoped<IUserService, UserService>();
// Add TaskService
builder.Services.AddScoped<ITaskService, TaskService>();
// Add TaskCategoryService
builder.Services.AddScoped<ITaskCategoryService, TaskCategoryService>();
// Add UserContextService
builder.Services.AddScoped<IUserContextService, UserContextService>();
// Add Validator for RegisterUser
builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserValidator>();

// Add AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// Add ErrorHandlingMiddleware
builder.Services.AddScoped<ErrorHandlingMiddleware>();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Password Hasher
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// Add seeder
builder.Services.AddScoped<DataBaseSeeder>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Add seeder
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<DataBaseSeeder>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
seeder.Seed();
app.MapControllers();
app.Run();