using fitnessApi.Models.Entities;

namespace fitnessApi.Repository.ExercicioRepository
{
    public interface IExercicioRepository : IRepository<Exercicios>
    {
        /// <summary>
        /// Retorna o exercício com o músculo e o grupo muscular carregados
        /// </summary>
        Exercicios GetWithMusculoAndGrupo(int id);
    }
}
