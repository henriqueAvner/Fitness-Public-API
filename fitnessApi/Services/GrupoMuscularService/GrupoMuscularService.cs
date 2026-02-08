using fitnessApi.Models.Entities;
using fitnessApi.Repository;
using fitnessApi.Services.Exceptions;

namespace fitnessApi.Services.GrupoMuscularService
{
    public class GrupoMuscularService : IService<GrupoMuscular>
    {
        private readonly IRepository<GrupoMuscular> _repository;

        public GrupoMuscularService(IRepository<GrupoMuscular> repository)
        {
            _repository = repository;
        }

        public List<GrupoMuscular> GetAll()
        {
            return _repository.GetAll();
        }

        public GrupoMuscular GetById(int id)
        {
            var grupo = _repository.GetById(id);
            
            if (grupo == null)
            {
                throw new NotFoundException("Grupo muscular", id);
            }
            
            return grupo;
        }

        public GrupoMuscular Add(GrupoMuscular entity)
        {
            if (string.IsNullOrWhiteSpace(entity.NomeGrupoMuscular))
            {
                throw new BadRequestException("Nome do grupo muscular é obrigatório.");
            }
            
            return _repository.Add(entity);
        }

        public GrupoMuscular Update(GrupoMuscular entity, int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
            {
                throw new NotFoundException("Grupo muscular", id);
            }
            
            return _repository.Update(entity, id);
        }

        public void Delete(int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
            {
                throw new NotFoundException("Grupo muscular", id);
            }
            
            // Regra de negócio: verificar se tem músculos vinculados antes de deletar
            // if (existing.Musculos.Any())
            // {
            //     throw new BadRequestException("Não é possível deletar grupo com músculos vinculados.");
            // }
            
            _repository.Delete(id);
        }
    }
}
