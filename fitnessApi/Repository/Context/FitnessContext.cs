using fitnessApi.Models.Entities;
using fitnessApi.Repository.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace fitnessApi.Repository.Context
{
    public class FitnessContext : DbContext
    {
        public FitnessContext()
        {
        }

        public FitnessContext(DbContextOptions<FitnessContext> options) : base(options)
        {
        }
        public DbSet<Exercicios> Exercicios { get; set; }
        public DbSet<GrupoMuscular> GruposMusculares { get; set; }
        public DbSet<Musculos> Musculos { get; set; }

        public string DbConn()
        {
            var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = configBuilder.Build();

            var config = configuration["ConnectionStrings:DefaultConnection"];

            return config;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConn());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica todas as configurações separadas
            modelBuilder.ApplyConfiguration(new GrupoMuscularConfiguration());
            modelBuilder.ApplyConfiguration(new MusculosConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciciosConfiguration());
        }

    }
}
