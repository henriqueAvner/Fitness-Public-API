using fitnessApi.Models.Entities;

namespace fitnessApi.Services.ExercicioService
{
    public interface IExercicioService : IService<Exercicios>
    {
        /// <summary>
        /// Retorna o exercício com o nome do músculo e o grupo muscular
        /// </summary>
        Exercicios GetWithMusculoAndGrupo(int id);
    }
}
