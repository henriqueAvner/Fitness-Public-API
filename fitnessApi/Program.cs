using fitnessApi.Middlewares;
using fitnessApi.Repository.Context;
using fitnessApi.Repository.ExercicioRepository;
using fitnessApi.Repository.GrupoMuscularRepository;
using fitnessApi.Repository.MusculosRepository;
using fitnessApi.Services.ExercicioService;
using fitnessApi.Services.GrupoMuscularService;
using fitnessApi.Services.MusculoService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<FitnessContext>();

// Repositories
builder.Services.AddScoped<IExercicioRepository, ExercicioRepository>();
builder.Services.AddScoped<IGrupoMuscularRepository, GrupoMuscularRepository>();
builder.Services.AddScoped<IMusculoRepository, MusculosRepository>();

// Services
builder.Services.AddScoped<IExercicioService, ExercicioService>();
builder.Services.AddScoped<IGrupoMuscularService, GrupoMuscularService>();
builder.Services.AddScoped<IMusculoService, MusculoService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Aplica migrations automaticamente na inicialização
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<FitnessContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
