using CidadeLimpa.Models;

namespace CidadeLimpa.Services
{
    public interface ICaminhaoService
    {
        IEnumerable<CaminhaoModel> ListarCaminhoes(int page);
        CaminhaoModel? ObterCaminhaoPorId(int id);
        void CriarCaminhao(CaminhaoModel model);
        void AtualizarCaminhao(CaminhaoModel model);
        void ExcluirCaminhao(int id);
    }
}
