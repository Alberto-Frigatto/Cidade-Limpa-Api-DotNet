using CidadeLimpa.Models;
using CidadeLimpa.Repository;

namespace CidadeLimpa.Services
{
    public class LixeiraService : ILixeiraService
    {
        private readonly ILixeiraRepository _repository;

        public LixeiraService(ILixeiraRepository repository)
        {
            _repository = repository;
        }

        public void AtualizarLixeira(LixeiraModel model) => _repository.Update(model);

        public void CriarLixeira(LixeiraModel model) => _repository.Add(model);

        public void ExcluirLixeira(int id)
        {
            var lixeira = _repository.GetById(id);

            if (lixeira != null)
                _repository.Delete(lixeira);
        }

        public IEnumerable<LixeiraModel> ListarLixeiras(int page) => _repository.GetAll(page);

        public LixeiraModel? ObterLixeiraPorId(int id) => _repository.GetById(id);
    }
}
