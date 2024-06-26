using CidadeLimpa.Models;
using CidadeLimpa.Repository;

namespace CidadeLimpa.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _repository;

        public AuthService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public UsuarioModel? Autenticar(string email, string senha)  => _repository.GetByEmailAndSenha(email, senha);
    }
}
