using CidadeLimpa.Models;
using CidadeLimpa.Repository;

namespace CidadeLimpa.Services
{
    public class RotaService : IRotaService
    {
        private readonly IRotaRepository _repository;

        public RotaService(IRotaRepository repository)
        {
            _repository = repository;
        }

        public void AtualizarRota(RotaModel model) => _repository.Update(model);

        public void CriarRota(RotaModel model) => _repository.Add(model);

        public void ExcluirRota(int id)
        {
            var rota = _repository.GetById(id);

            if (rota != null)
                _repository.Delete(rota);          
        }

        public IEnumerable<RotaModel> ListarRotas(int page) => _repository.GetAll(page);

        public RotaModel? ObterRotaPorId(int id) => _repository.GetById(id);
    }
}
