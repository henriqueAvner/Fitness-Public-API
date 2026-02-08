using fitnessApi.Models.Entities;

namespace fitnessApi.Repository.GrupoMuscularRepository
{
    public interface IGrupoMuscularRepository : IRepository<GrupoMuscular>
    {
        /// <summary>
        /// Retorna o grupo muscular com todos os músculos carregados
        /// </summary>
        GrupoMuscular GetWithMusculos(int id);
    }
}
