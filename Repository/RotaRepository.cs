using CidadeLimpa.Data.Contexts;
using CidadeLimpa.Models;
using Microsoft.EntityFrameworkCore;

namespace CidadeLimpa.Repository
{
    public class RotaRepository : IRotaRepository
    {
        private readonly DatabaseContext _context;

        public RotaRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(RotaModel model)
        {
            _context.Rotas.Add(model);
            _context.SaveChanges();
        }

        public void Delete(RotaModel model)
        {
            _context.Rotas.Remove(model);
            _context.SaveChanges();
        }

        public IEnumerable<RotaModel> GetAll(int page)
        {
            return _context.Rotas.Include(e => e.ListaPontosColeta).Skip((page - 1) * page).Take(20).AsNoTracking().ToList();
        }

        public RotaModel? GetById(int id) => _context.Rotas.Include(e => e.ListaPontosColeta).FirstOrDefault(e => e.Id == id);

        public void Update(RotaModel model)
        {
            _context.Rotas.Update(model);
            _context.SaveChanges();
        }
    }
}
