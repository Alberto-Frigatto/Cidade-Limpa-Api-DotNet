using CidadeLimpa.Data.Contexts;
using CidadeLimpa.Models;
using Microsoft.EntityFrameworkCore;

namespace CidadeLimpa.Repository
{
    public class LixeiraParaColetaRepository : ILixeiraParaColetaRepository
    {
        private readonly DatabaseContext _context;

        public LixeiraParaColetaRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(LixeiraParaColetaModel model)
        {
            _context.LixeirasParaColeta.Add(model);
            _context.SaveChanges();
        }

        public void Delete(LixeiraParaColetaModel model)
        {
            _context.LixeirasParaColeta.Remove(model);
            _context.SaveChanges();
        }

        public IEnumerable<LixeiraParaColetaModel> GetAll(int page)
        {
            return _context.LixeirasParaColeta.Include(e => e.Lixeira).Skip((page - 1) * page).Take(20).AsNoTracking().ToList();
        }

        public LixeiraParaColetaModel? GetById(int id) => _context.LixeirasParaColeta.Include(e => e.Lixeira).FirstOrDefault(e => e.Id == id);

        public void Update(LixeiraParaColetaModel model)
        {
            _context.LixeirasParaColeta.Update(model);
            _context.SaveChanges();
        }
    }
}
