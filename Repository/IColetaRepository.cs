using CidadeLimpa.Models;

namespace CidadeLimpa.Repository
{
    public interface IColetaRepository
    {
        IEnumerable<ColetaModel> GetAll(int page);
        ColetaModel? GetById(int id);
        void Add(ColetaModel model);
        void Delete(ColetaModel model);
    }
}
