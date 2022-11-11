using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SSYS.API.IAM.Authorization.Handlers.Implementations;
using SSYS.API.IAM.Authorization.Handlers.Interfaces;
using SSYS.API.IAM.Authorization.Middleware;
using SSYS.API.IAM.Authorization.Settings;
using SSYS.API.IAM.Domain.Repositories;
using SSYS.API.IAM.Domain.Services;
using SSYS.API.IAM.Persistence.Repositories;
using SSYS.API.IAM.Services;
using SSYS.API.SCM.Domain.Repositories;
using SSYS.API.Shared.Domain.Repositories;
using SSYS.API.Shared.Persistence.Contexts;
using SSYS.API.Shared.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add Database Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// AppSetting Configuration
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddDbContext<AppDbContext>(
    option => option.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Security Bounded Context Dependencies Injection Configuration
builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Automapper
builder.Services.AddAutoMapper(
    typeof(SSYS.API.IAM.Mapping.ModelToResourceProfile),
    typeof(SSYS.API.IAM.Mapping.ResourceToModelProfile)
    );

// Swagger Configuration
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SSYS API",
        Description = "SSYS Web Service",
        TermsOfService = new Uri("https://upc-pre-202202-si70-wv51-samsantech.github.io/landingpage-ssys/tos"),
        Contact = new OpenApiContact
        {
            Name = "SSYS.PE",
            Url = new Uri("https://www.ssys.pe")
        },
        License = new OpenApiLicense
        {
            Name = "Samsan Tech SSYS Resource License",
            Url = new Uri("https://upc-pre-202202-si70-wv51-samsantech.github.io/landingpage-ssys/license")
        }

    });
    options.EnableAnnotations();
});


// Appsettings configuration
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

// Configure CORS
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure Error Handler Middleware
app.UseMiddleware<ErrorHandlerMiddleware>();


// Configure JWT Handling Middleware
app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program{}