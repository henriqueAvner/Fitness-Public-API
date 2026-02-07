using fitnessApi.Models.Entities;
using fitnessApi.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace fitnessApi.Repository.MusculosRepository
{
    public class MusculosRepository : IRepository<Musculos>
    {

        private readonly FitnessContext _context;
        public List<Musculos> GetAll()
        {
            return _context.Musculos.ToList();
        }

        public Musculos GetById(int id)
        {
            var findEntity = _context.Musculos.Find(id);
            if (findEntity != null)
            {
                return findEntity;
            }
            return null!;
        }

        public Musculos Add(Musculos entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;

        }
        public Musculos Update(Musculos entity, int id)
        {
            Musculos findMuscle = _context.Musculos.Find(id)!;

            if (findMuscle != null)
            {
                _context.Musculos.Add(entity);
                _context.SaveChanges();
            }
            return entity;
        }

        public void Delete(int id)
        {
            var musculo = _context.Musculos.Include(m => m.Exercicios)
                .Single(m => m.Id == id);

            // Remove todos os Exercicios associados ao Musculo
            if (musculo.Exercicios != null && musculo.Exercicios.Count > 0)
            {
                _context.Exercicios.RemoveRange(musculo.Exercicios);
            }

            _context.Musculos.Remove(musculo);
            _context.SaveChanges();
        }


    }
}
