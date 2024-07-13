using CidadeLimpa.Models;

namespace CidadeLimpa.Repository
{
    public interface IUsuarioRepository
    {
        UsuarioModel? GetByEmailAndSenha(string email, string senha);
        UsuarioModel? GetByEmail(string email);
        void Add(UsuarioModel model);
    }
}
