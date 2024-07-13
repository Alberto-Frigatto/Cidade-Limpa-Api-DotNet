using CidadeLimpa.Models;
using CidadeLimpa.Repository;

namespace CidadeLimpa.Services
{
    public class ColetaService : IColetaService
    {
        private readonly IColetaRepository _repository;

        public ColetaService(IColetaRepository repository)
        {
            _repository = repository;
        }

        public void CriarColeta(ColetaModel model) => _repository.Add(model);

        public void ExcluirColeta(int id)
        {
            var coleta = _repository.GetById(id);

            if (coleta != null)
                _repository.Delete(coleta);
        }

        public IEnumerable<ColetaModel> ListarColetas(int page) => _repository.GetAll(page);

        public ColetaModel? ObterColetaPorId(int id) => _repository.GetById(id);
    }
}
