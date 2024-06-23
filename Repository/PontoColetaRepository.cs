using CidadeLimpa.Data.Contexts;
using CidadeLimpa.Models;

namespace CidadeLimpa.Repository
{
    public class PontoColetaRepository : IPontoColetaRepository
    {
        private readonly DatabaseContext _context;

        public PontoColetaRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(PontoColetaModel model)
        {
            _context.PontosColeta.Add(model);
            _context.SaveChanges();
        }

        public void Delete(PontoColetaModel model)
        {
            _context.PontosColeta.Remove(model);
            _context.SaveChanges();
        }

        public PontoColetaModel? GetById(int id) => _context.PontosColeta.Find(id);
    }
}
