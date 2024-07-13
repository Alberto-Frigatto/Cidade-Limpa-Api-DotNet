using CidadeLimpa.Models;

namespace CidadeLimpa.Services
{
    public interface ILixeiraParaColetaService
    {
        IEnumerable<LixeiraParaColetaModel> ListarLixeirasParaColeta(int page);
        LixeiraParaColetaModel? ObterLixeiraParaColetaPorId(int id);
        void CriarLixeiraParaColeta(LixeiraParaColetaModel model);
        void AtualizarLixeiraParaColeta(LixeiraParaColetaModel model);
        void ExcluirLixeiraParaColeta(int id);
    }
}
