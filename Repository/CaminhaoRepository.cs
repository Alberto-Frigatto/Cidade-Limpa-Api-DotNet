using CidadeLimpa.Data.Contexts;
using CidadeLimpa.Models;
using Microsoft.EntityFrameworkCore;

namespace CidadeLimpa.Repository
{
    public class CaminhaoRepository : ICaminhaoRepository
    {
        private readonly DatabaseContext _context;

        public CaminhaoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(CaminhaoModel model)
        {
            _context.Caminhoes.Add(model);
            _context.SaveChanges();
        }

        public void Delete(CaminhaoModel model)
        {
            _context.Caminhoes.Remove(model);
            _context.SaveChanges();
        }

        public IEnumerable<CaminhaoModel> GetAll(int page)
        {
            return _context.Caminhoes.Include(e => e.Rota).Include(e => e.Rota.ListaPontosColeta).Skip((page - 1) * page).Take(20).AsNoTracking().ToList();
        }

        public CaminhaoModel? GetById(int id) => _context.Caminhoes.Include(e => e.Rota).Include(e => e.Rota.ListaPontosColeta).FirstOrDefault(e => e.Id == id);

        public void Update(CaminhaoModel model)
        {
            _context.Caminhoes.Update(model);
            _context.SaveChanges();
        }
    }
}
