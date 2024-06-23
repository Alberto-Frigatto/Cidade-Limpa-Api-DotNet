using CidadeLimpa.Models;

namespace CidadeLimpa.Services
{
    public interface IPontoColetaService
    {
        void CriarPontoColeta(PontoColetaModel model);
        void ExcluirPontoColeta(int id);
    }
}
