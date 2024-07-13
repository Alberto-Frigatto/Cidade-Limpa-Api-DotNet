using CidadeLimpa.Data.Contexts;
using CidadeLimpa.Models;

namespace CidadeLimpa.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DatabaseContext _context;

        public UsuarioRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(UsuarioModel model)
        {
            _context.Usuarios.Add(model);
            _context.SaveChanges();
        }

        public UsuarioModel? GetByEmail(string email) => _context.Usuarios.FirstOrDefault(e => e.Email == email);
        public UsuarioModel? GetByEmailAndSenha(string email, string senha) => _context.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha  == senha);
    }
}
