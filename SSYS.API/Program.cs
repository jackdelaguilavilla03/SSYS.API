using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SSYS.API.IAM.Authorization.Settings;
using SSYS.API.SCM.Domain.Repositories;
using SSYS.API.SCM.Domain.Services;
using SSYS.API.SCM.Mapping;
using SSYS.API.SCM.Persistence;
using SSYS.API.Shared.Domain.Repositories;
using SSYS.API.Shared.Persistence.Contexts;
using SSYS.API.Shared.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// AppSetting Configuration
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
// Sawgger Configuration


var connectionsString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionsString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, ICategoryService>();

builder.Services.AddAutoMapper(
    typeof(SSYS.API.SCM.Mapping.ModelToResourceCategory),
    typeof(SSYS.API.SCM.Mapping.ResourceToModelCategory)
);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SSYS API",
        Description = "SSYS Web Service",
        Contact = new OpenApiContact
        {
            Name = "SSYS.PE",
            Url = new Uri("https://www.ssys.pe")
        }

    });
});






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();