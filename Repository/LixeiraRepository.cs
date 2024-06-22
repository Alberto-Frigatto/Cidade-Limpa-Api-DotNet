using CidadeLimpa.Data.Contexts;
using CidadeLimpa.Models;
using Microsoft.EntityFrameworkCore;

namespace CidadeLimpa.Repository
{
    public class LixeiraRepository : ILixeiraRepository
    {
        private readonly DatabaseContext _context;

        public LixeiraRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(LixeiraModel model)
        {
            _context.Lixeiras.Add(model);
            _context.SaveChanges();
        }

        public void Delete(LixeiraModel model)
        {
            _context.Lixeiras.Remove(model);
            _context.SaveChanges();
        }

        public IEnumerable<LixeiraModel> GetAll(int page)
        {
            return _context.Lixeiras.Skip((page - 1) * page).Take(20).AsNoTracking().ToList();
        }

        public LixeiraModel? GetById(int id) => _context.Lixeiras.Find(id);

        public void Update(LixeiraModel model)
        {
            _context.Lixeiras.Update(model);
            _context.SaveChanges();
        }
    }
}
