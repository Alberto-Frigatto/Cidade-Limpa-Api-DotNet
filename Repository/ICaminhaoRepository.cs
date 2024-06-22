using CidadeLimpa.Models;

namespace CidadeLimpa.Repository
{
    public interface ICaminhaoRepository
    {
        IEnumerable<CaminhaoModel> GetAll(int page);
        CaminhaoModel? GetById(int id);
        void Add(CaminhaoModel model);
        void Update(CaminhaoModel model);
        void Delete(CaminhaoModel model);
    }
}