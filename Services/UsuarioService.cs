using CidadeLimpa.Models;
using CidadeLimpa.Repository;

namespace CidadeLimpa.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public void CriarUsuario(UsuarioModel model) => _repository.Add(model);

        public UsuarioModel? ObterUsuarioPorEmail(string email) => _repository.GetByEmail(email);
    }
}
