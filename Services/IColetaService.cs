using CidadeLimpa.Models;

namespace CidadeLimpa.Services
{
    public interface IColetaService
    {
        IEnumerable<ColetaModel> ListarColetas(int page);
        ColetaModel? ObterColetaPorId(int id);
        void CriarColeta(ColetaModel model);
        void ExcluirColeta(int id);
    }
}
