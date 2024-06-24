using CidadeLimpa.Models;

namespace CidadeLimpa.Repository
{
    public interface IUsuarioRepository
    {
        UsuarioModel? GetByEmail(string email);
        void Add(UsuarioModel model);
        void Update(UsuarioModel model);
        void Delete(UsuarioModel model);
    }
}
