using CidadeLimpa.Models;
using CidadeLimpa.Repository;

namespace CidadeLimpa.Services
{
    public class CaminhaoService : ICaminhaoService
    {
        private readonly ICaminhaoRepository _repository;

        public CaminhaoService(ICaminhaoRepository repository)
        {
            _repository = repository;
        }

        public void AtualizarCaminhao(CaminhaoModel model) => _repository.Update(model);

        public void CriarCaminhao(CaminhaoModel model) => _repository.Add(model);

        public void ExcluirCaminhao(int id)
        {
            var caminhao = _repository.GetById(id);

            if (caminhao != null)
                _repository.Delete(caminhao);
        }

        public IEnumerable<CaminhaoModel> ListarCaminhoes(int page) => _repository.GetAll(page);

        public CaminhaoModel? ObterCaminhaoPorId(int id) => _repository.GetById(id);
    }
}
