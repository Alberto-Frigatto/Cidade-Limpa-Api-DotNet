using CidadeLimpa.Models;
using CidadeLimpa.Repository;

namespace CidadeLimpa.Services
{
    public class PontoColetaService : IPontoColetaService
    {
        private readonly IPontoColetaRepository _repository;

        public PontoColetaService(IPontoColetaRepository repository)
        {
            _repository = repository;
        }

        public void CriarPontoColeta(PontoColetaModel model) => _repository.Add(model);

        public void ExcluirPontoColeta(int id)
        {
            var pontoColeta = _repository.GetById(id);

            if (pontoColeta != null)
            {
                _repository.Delete(pontoColeta);
            }
        }
    }
}
