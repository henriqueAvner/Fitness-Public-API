using fitnessApi.Middlewares;
using fitnessApi.Repository.Context;
using fitnessApi.Repository.ExercicioRepository;
using fitnessApi.Repository.GrupoMuscularRepository;
using fitnessApi.Repository.MusculosRepository;
using fitnessApi.Services.ExercicioService;
using fitnessApi.Services.GrupoMuscularService;
using fitnessApi.Services.MusculoService;
using Microsoft.EntityFrameworkCore;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// CORS - permite qualquer origem (API pública)
builder.Services.AddCors(options =>
{
    options.AddPolicy("PublicApi", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Rate Limiting - 100 requisições por minuto por IP
builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: context.Connection.RemoteIpAddress?.ToString() ?? "anonymous",
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 100,
                Window = TimeSpan.FromMinutes(1),
                QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                QueueLimit = 0
            }));
    
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
});

// Configuração do banco de dados (SQLite em produção, SQL Server em desenvolvimento)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var useSqlite = builder.Configuration.GetValue<bool>("UseSqlite");

builder.Services.AddDbContext<FitnessContext>(options =>
{
    if (useSqlite)
    {
        options.UseSqlite("Data Source=fitness.db");
        Console.WriteLine("Usando SQLite como banco de dados.");
    }
    else
    {
        options.UseSqlServer(connectionString);
        Console.WriteLine("Usando SQL Server como banco de dados.");
    }
});

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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() 
    { 
        Title = "Fitness API", 
        Version = "v1",
        Description = "API pública de consulta de exercícios, músculos e grupos musculares",
        Contact = new() { Name = "Fitness API" }
    });
});

var app = builder.Build();

// Aplica migrations automaticamente na inicialização
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<FitnessContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

// Swagger disponível em todos os ambientes (API pública)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fitness API v1");
    c.RoutePrefix = string.Empty; // Swagger na raiz (/)
});

app.UseHttpsRedirection();

app.UseCors("PublicApi");

app.UseRateLimiter();

app.UseAuthorization();

app.MapControllers();

app.Run();
