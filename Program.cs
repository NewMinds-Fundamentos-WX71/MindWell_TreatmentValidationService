using Microsoft.EntityFrameworkCore;
using MindWell_TreatmentValidation.Shared.Persistence.Contexts;
using MindWell_TreatmentValidation.Shared.Persistence.Repositories;
using MindWell_TreatmentValidation.TreatmentValidation.Domain.Repositories;
using MindWell_TreatmentValidation.TreatmentValidation.Domain.Services;
using MindWell_TreatmentValidation.TreatmentValidation.Mapping;
using MindWell_TreatmentValidation.TreatmentValidation.Persistence.Repositories;
using MindWell_TreatmentValidation.TreatmentValidation.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors());

// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency injection
builder.Services.AddScoped<ITreatmentValidationRepository, TreatmentValidationRepository>();
builder.Services.AddScoped<ITreatmentValidationService, TreatmentValidationService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));

var app = builder.Build();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

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
