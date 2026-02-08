using fitnessApi.Repository.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FitnessApi.Tests.IntegrationTests
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        private readonly string _databaseName = $"FitnessTestDb_{Guid.NewGuid()}";

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove o DbContext existente
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<FitnessContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Adiciona o DbContext InMemory para testes com nome único
                services.AddDbContext<FitnessContext>(options =>
                {
                    options.UseInMemoryDatabase(_databaseName);
                });
            });

            builder.UseEnvironment("Testing");
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            var host = base.CreateHost(builder);

            // Seed data após o host ser criado
            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<FitnessContext>();
                db.Database.EnsureCreated();
                
                // Só faz seed se não houver dados
                if (!db.GruposMusculares.Any())
                {
                    SeedTestData(db);
                }
            }

            return host;
        }

        private static void SeedTestData(FitnessContext context)
        {
            // Adicionar grupos musculares
            var grupoPeito = new fitnessApi.Models.Entities.GrupoMuscular
            {
                Id = 1,
                NomeGrupoMuscular = "Peito",
                DescricaoGrupo = "Grupo muscular peitoral"
            };

            var grupoCostas = new fitnessApi.Models.Entities.GrupoMuscular
            {
                Id = 2,
                NomeGrupoMuscular = "Costas",
                DescricaoGrupo = "Grupo muscular dorsal"
            };

            var grupoBraco = new fitnessApi.Models.Entities.GrupoMuscular
            {
                Id = 3,
                NomeGrupoMuscular = "Braço",
                DescricaoGrupo = "Músculos do braço"
            };

            context.GruposMusculares.AddRange(grupoPeito, grupoCostas, grupoBraco);
            context.SaveChanges();

            // Adicionar músculos
            var peitoral = new fitnessApi.Models.Entities.Musculos
            {
                Id = 1,
                NomeMusculo = "Peitoral Maior",
                MovimentoPrincipal = "Flexão horizontal",
                Funcao = "Adução do braço",
                TipoTecido = "Estriado esquelético",
                GrupoMuscularId = 1,
                FibraMuscular = "Mista"
            };

            var latissimo = new fitnessApi.Models.Entities.Musculos
            {
                Id = 2,
                NomeMusculo = "Latíssimo do Dorso",
                MovimentoPrincipal = "Extensão do ombro",
                Funcao = "Adução e rotação medial",
                TipoTecido = "Estriado esquelético",
                GrupoMuscularId = 2,
                FibraMuscular = "Mista"
            };

            var biceps = new fitnessApi.Models.Entities.Musculos
            {
                Id = 3,
                NomeMusculo = "Bíceps Braquial",
                MovimentoPrincipal = "Flexão do cotovelo",
                Funcao = "Supinação do antebraço",
                TipoTecido = "Estriado esquelético",
                GrupoMuscularId = 3,
                FibraMuscular = "Mista"
            };

            context.Musculos.AddRange(peitoral, latissimo, biceps);
            context.SaveChanges();

            // Adicionar exercícios
            var supino = new fitnessApi.Models.Entities.Exercicios
            {
                Id = 1,
                NomeExercicio = "Supino Reto",
                DescricaoExercicio = "Exercício para desenvolvimento do peitoral",
                MusculosId = 1
            };

            var puxada = new fitnessApi.Models.Entities.Exercicios
            {
                Id = 2,
                NomeExercicio = "Puxada Frontal",
                DescricaoExercicio = "Exercício para desenvolvimento das costas",
                MusculosId = 2
            };

            var rosca = new fitnessApi.Models.Entities.Exercicios
            {
                Id = 3,
                NomeExercicio = "Rosca Direta",
                DescricaoExercicio = "Exercício para desenvolvimento do bíceps",
                MusculosId = 3
            };

            context.Exercicios.AddRange(supino, puxada, rosca);
            context.SaveChanges();
        }
    }
}
