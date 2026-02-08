using fitnessApi.Models.Entities;
using fitnessApi.Repository.GrupoMuscularRepository;
using fitnessApi.Services.Exceptions;

namespace fitnessApi.Services.GrupoMuscularService
{
    public class GrupoMuscularService : IGrupoMuscularService
    {
        private readonly IGrupoMuscularRepository _repository;

        public GrupoMuscularService(IGrupoMuscularRepository repository)
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
            
            _repository.Delete(id);
        }

        /// <summary>
        /// Retorna o grupo muscular com todos os músculos
        /// </summary>
        public GrupoMuscular GetWithMusculos(int id)
        {
            var grupo = _repository.GetWithMusculos(id);
            
            if (grupo == null)
            {
                throw new NotFoundException("Grupo muscular", id);
            }
            
            return grupo;
        }
    }
}
}
