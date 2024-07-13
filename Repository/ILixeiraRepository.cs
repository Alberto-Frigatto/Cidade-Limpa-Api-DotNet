using CidadeLimpa.Models;

namespace CidadeLimpa.Repository
{
    public interface ILixeiraRepository
    {
        IEnumerable<LixeiraModel> GetAll(int page);
        LixeiraModel? GetById(int id);
        void Add(LixeiraModel model);
        void Update(LixeiraModel model);
        void Delete(LixeiraModel model);
    }
}
