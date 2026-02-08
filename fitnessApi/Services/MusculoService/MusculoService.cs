using fitnessApi.Models.Entities;
using fitnessApi.Repository.MusculosRepository;
using fitnessApi.Services.Exceptions;

namespace fitnessApi.Services.MusculoService
{
    public class MusculoService : IMusculoService
    {
        private readonly IMusculoRepository _repository;

        public MusculoService(IMusculoRepository repository)
        {
            _repository = repository;
        }

        public List<Musculos> GetAll()
        {
            return _repository.GetAll();
        }

        public Musculos GetById(int id)
        {
            var musculo = _repository.GetById(id);
            
            if (musculo == null)
            {
                throw new NotFoundException("Músculo", id);
            }
            
            return musculo;
        }

        public Musculos Add(Musculos entity)
        {
            if (string.IsNullOrWhiteSpace(entity.NomeMusculo))
            {
                throw new BadRequestException("Nome do músculo é obrigatório.");
            }
            
            return _repository.Add(entity);
        }

        public Musculos Update(Musculos entity, int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
            {
                throw new NotFoundException("Músculo", id);
            }
            
            return _repository.Update(entity, id);
        }

        public void Delete(int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
            {
                throw new NotFoundException("Músculo", id);
            }
            
            _repository.Delete(id);
        }

        /// <summary>
        /// Retorna o músculo com o grupo e todos os exercícios
        /// </summary>
        public Musculos GetWithGrupoAndExercicios(int id)
        {
            var musculo = _repository.GetWithGrupoAndExercicios(id);
            
            if (musculo == null)
            {
                throw new NotFoundException("Músculo", id);
            }
            
            return musculo;
        }
    }
}

