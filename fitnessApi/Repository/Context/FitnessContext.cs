using fitnessApi.Models.Entities;
using fitnessApi.Repository.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace fitnessApi.Repository.Context
{
    public class FitnessContext : DbContext
    {
        public FitnessContext(DbContextOptions<FitnessContext> options) : base(options)
        {
        }

        public DbSet<Exercicios> Exercicios { get; set; }
        public DbSet<GrupoMuscular> GruposMusculares { get; set; }
        public DbSet<Musculos> Musculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica todas as configurações separadas
            modelBuilder.ApplyConfiguration(new GrupoMuscularConfiguration());
            modelBuilder.ApplyConfiguration(new MusculosConfiguration());
            modelBuilder.ApplyConfiguration(new ExerciciosConfiguration());
        }
    }
}
