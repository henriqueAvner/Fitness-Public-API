using fitnessApi.Models.Entities;
using fitnessApi.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace fitnessApi.Repository.GrupoMuscularRepository
{
    public class GrupoMuscularRepository : IGrupoMuscularRepository
    {
        private readonly FitnessContext _context;

        public GrupoMuscularRepository(FitnessContext context)
        {
            _context = context;
        }

        public GrupoMuscular Add(GrupoMuscular entity)
        {
            _context.GruposMusculares.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var findGrupoMuscular = _context.GruposMusculares.Find(id);
            if (findGrupoMuscular != null)
            {
                _context.GruposMusculares.Remove(findGrupoMuscular);
                _context.SaveChanges();
            }
        }

        public List<GrupoMuscular> GetAll()
        {
           return _context.GruposMusculares.ToList();
        }

        public GrupoMuscular GetById(int id)
        {
            return _context.GruposMusculares.Find(id)!;
        }

        public GrupoMuscular Update(GrupoMuscular entity, int id)
        {
            var findGrupoMuscular = GetById(id);
            if (findGrupoMuscular != null)
            {
                _context.GruposMusculares.Update(entity);
                _context.SaveChanges();
            }
            return entity;
        }

        /// <summary>
        /// Retorna o grupo muscular com todos os músculos carregados
        /// </summary>
        public GrupoMuscular GetWithMusculos(int id)
        {
            return _context.GruposMusculares
                .Include(g => g.Musculos)    // Carrega todos os músculos do grupo
                .FirstOrDefault(g => g.Id == id);
        }
    }
}
