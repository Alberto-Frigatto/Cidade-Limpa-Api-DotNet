using CidadeLimpa.Models;

namespace CidadeLimpa.Repository
{
    public interface IRotaRepository
    {
        IEnumerable<RotaModel> GetAll(int page);
        RotaModel? GetById(int id);
        void Add(RotaModel model);
        void Update(RotaModel model);
        void Delete(RotaModel model);
    }
}
