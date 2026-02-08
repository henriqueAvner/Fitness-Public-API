using fitnessApi.Models.Entities;
using fitnessApi.Repository;
using fitnessApi.Services.Exceptions;

namespace fitnessApi.Services.ExercicioService
{
    public class ExercicioService : IService<Exercicios>
    {
        private readonly IRepository<Exercicios> _repository;

        public ExercicioService(IRepository<Exercicios> repository)
        {
            _repository = repository;
        }

        public List<Exercicios> GetAll()
        {
            return _repository.GetAll();
        }

        public Exercicios GetById(int id)
        {
            var exercicio = _repository.GetById(id);
            
            if (exercicio == null)
            {
                throw new NotFoundException("Exercício", id);
            }
            
            return exercicio;
        }

        public Exercicios Add(Exercicios entity)
        {
            if (string.IsNullOrWhiteSpace(entity.NomeExercicio))
            {
                throw new BadRequestException("Nome do exercício é obrigatório.");
            }
            
            return _repository.Add(entity);
        }

        public Exercicios Update(Exercicios entity, int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
            {
                throw new NotFoundException("Exercício", id);
            }
            
            return _repository.Update(entity, id);
        }

        public void Delete(int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
            {
                throw new NotFoundException("Exercício", id);
            }
            
            _repository.Delete(id);
        }
    }
}
