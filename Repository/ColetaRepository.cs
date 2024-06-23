using CidadeLimpa.Data.Contexts;
using CidadeLimpa.Models;
using Microsoft.EntityFrameworkCore;

namespace CidadeLimpa.Repository
{
    public class ColetaRepository : IColetaRepository
    {
        private readonly DatabaseContext _context;

        public ColetaRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(ColetaModel model)
        {
            _context.Coletas.Add(model);
            _context.SaveChanges();
        }

        public void Delete(ColetaModel model)
        {
            _context.Coletas.Remove(model);
            _context.SaveChanges();
        }

        public IEnumerable<ColetaModel> GetAll(int page)
        {
            return _context.Coletas.Include(e => e.Caminhao).Include(e => e.Lixeira).Skip((page - 1) * page).Take(20).AsNoTracking().ToList();
        }

        public ColetaModel? GetById(int id) => _context.Coletas.Include(e => e.Caminhao).Include(e => e.Lixeira).FirstOrDefault(e => e.Id == id);
    }
}
