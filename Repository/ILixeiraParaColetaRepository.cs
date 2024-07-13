using CidadeLimpa.Models;

namespace CidadeLimpa.Repository
{
    public interface ILixeiraParaColetaRepository
    {
        IEnumerable<LixeiraParaColetaModel> GetAll(int page);
        LixeiraParaColetaModel? GetById(int id);
        void Add(LixeiraParaColetaModel model);
        void Update(LixeiraParaColetaModel model);
        void Delete(LixeiraParaColetaModel model);
    }
}
