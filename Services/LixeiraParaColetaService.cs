using CidadeLimpa.Models;
using CidadeLimpa.Repository;

namespace CidadeLimpa.Services
{
    public class LixeiraParaColetaService : ILixeiraParaColetaService
    {
        private readonly ILixeiraParaColetaRepository _repository;

        public LixeiraParaColetaService(ILixeiraParaColetaRepository repository)
        {
            _repository = repository;
        }   

        public void AtualizarLixeiraParaColeta(LixeiraParaColetaModel model) => _repository.Update(model);

        public void CriarLixeiraParaColeta(LixeiraParaColetaModel model) => _repository.Add(model);

        public void ExcluirLixeiraParaColeta(int id)
        {
            var lixeira = _repository.GetById(id);

            if (lixeira != null)
                _repository.Delete(lixeira);
        }

        public IEnumerable<LixeiraParaColetaModel> ListarLixeirasParaColeta(int page) => _repository.GetAll(page);

        public LixeiraParaColetaModel? ObterLixeiraParaColetaPorId(int id) => _repository.GetById(id);
    }
}
