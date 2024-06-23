using CidadeLimpa.Models;

namespace CidadeLimpa.Services
{
    public interface IRotaService
    {
        IEnumerable<RotaModel> ListarRotas(int page);
        RotaModel? ObterRotaPorId(int id);
        void CriarRota(RotaModel model);
        void AtualizarRota(RotaModel model);
        void ExcluirRota(int id);
    }
}
