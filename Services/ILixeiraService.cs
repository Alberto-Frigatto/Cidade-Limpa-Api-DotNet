using CidadeLimpa.Models;

namespace CidadeLimpa.Services
{
    public interface ILixeiraService
    {
        IEnumerable<LixeiraModel> ListarLixeiras(int page);
        LixeiraModel? ObterLixeiraPorId(int id);
        void CriarLixeira(LixeiraModel model);
        void AtualizarLixeira(LixeiraModel model);
        void ExcluirLixeira(int id);
    }
}
