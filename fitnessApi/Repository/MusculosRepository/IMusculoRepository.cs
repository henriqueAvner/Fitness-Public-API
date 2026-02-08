using fitnessApi.Models.Entities;

namespace fitnessApi.Repository.MusculosRepository
{
    public interface IMusculoRepository : IRepository<Musculos>
    {
        /// <summary>
        /// Retorna o músculo com o grupo muscular e todos os exercícios carregados
        /// </summary>
        Musculos GetWithGrupoAndExercicios(int id);
    }
}
