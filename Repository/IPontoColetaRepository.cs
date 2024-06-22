using CidadeLimpa.Models;

namespace CidadeLimpa.Repository
{
    public interface IPontoColetaRepository
    {
        void Add(PontoColetaModel model);
        void Delete(PontoColetaModel model);
    }
}
