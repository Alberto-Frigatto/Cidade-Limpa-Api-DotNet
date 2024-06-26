using CidadeLimpa.Models;

namespace CidadeLimpa.Services
{
    public interface IAuthService
    {
        UsuarioModel? Autenticar(string email, string senha);
    }
}
