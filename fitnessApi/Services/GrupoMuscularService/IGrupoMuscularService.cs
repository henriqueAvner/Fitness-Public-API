using fitnessApi.Models.Entities;

namespace fitnessApi.Services.GrupoMuscularService
{
    public interface IGrupoMuscularService : IService<GrupoMuscular>
    {
        /// <summary>
        /// Retorna o grupo muscular com todos os músculos
        /// </summary>
        GrupoMuscular GetWithMusculos(int id);
    }
}
