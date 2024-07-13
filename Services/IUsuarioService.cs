using CidadeLimpa.Models;

namespace CidadeLimpa.Services
{
    public interface IUsuarioService
    {
        UsuarioModel? ObterUsuarioPorEmail(string email);
        void CriarUsuario(UsuarioModel model);
    }
}
