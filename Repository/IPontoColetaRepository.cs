using CidadeLimpa.Models;

namespace CidadeLimpa.Repository
{
    public interface IPontoColetaRepository
    {
        PontoColetaModel? GetById(int id);
        void Add(PontoColetaModel model);
        void Delete(PontoColetaModel model);
    }
}
