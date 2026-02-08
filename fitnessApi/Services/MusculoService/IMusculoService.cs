using fitnessApi.Models.Entities;

namespace fitnessApi.Services.MusculoService
{
    public interface IMusculoService : IService<Musculos>
    {
        /// <summary>
        /// Retorna o músculo com o grupo e todos os exercícios
        /// </summary>
        Musculos GetWithGrupoAndExercicios(int id);
    }
}
