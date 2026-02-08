using fitnessApi.Models.Entities;
using fitnessApi.Repository;
using fitnessApi.Services.Exceptions;

namespace fitnessApi.Services.MusculoService
{
    public class MusculoService : IService<Musculos>
    {
        private readonly IRepository<Musculos> _repository;

        public MusculoService(IRepository<Musculos> repository)
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
            
            // Regra de negócio: verificar se tem exercícios vinculados
            // if (existing.Exercicios.Any())
            // {
            //     throw new BadRequestException("Não é possível deletar músculo com exercícios vinculados.");
            // }
            
            _repository.Delete(id);
        }
    }
}
