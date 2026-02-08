using fitnessApi.Models.Entities;
using fitnessApi.Repository;
using fitnessApi.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace fitnessApi.Repository.ExercicioRepository
{
    public class ExercicioRepository : IExercicioRepository
    {
        private readonly FitnessContext _context;

        public ExercicioRepository(FitnessContext context)
        {
            _context = context;
        }

        public Exercicios Add(Exercicios entity)
        {
            _context.Exercicios.Add(entity);
            _context.SaveChanges();
            return entity;

        }

        public void Delete(int id)
        {
            var findEntity = _context.Exercicios.Find(id);
            if (findEntity != null)
            {
                _context.Exercicios.Remove(findEntity);
                _context.SaveChanges();
            }
        }

        public List<Exercicios> GetAll()
        {
            return _context.Exercicios.ToList();
        }

        public Exercicios GetById(int id)
        {
           var findEntity = _context.Exercicios.Find(id);
            if (findEntity != null)
            {
                return findEntity;
            }
            return null;
        }

        public Exercicios Update(Exercicios entity, int id)
        {
            var findEntity = _context.Exercicios.Find(id);
            if(findEntity != null)
            {
              _context.Exercicios.Update(entity);
            }            
            _context.SaveChanges();
            return findEntity!;
        }

        /// <summary>
        /// Retorna o exercício com o músculo e o grupo muscular carregados
        /// </summary>
        public Exercicios GetWithMusculoAndGrupo(int id)
        {
            return _context.Exercicios
                .Include(e => e.Musculos)                    // Carrega o músculo
                    .ThenInclude(m => m.GrupoMuscular)       // Carrega o grupo do músculo
                .FirstOrDefault(e => e.Id == id);
        }
    }
}
