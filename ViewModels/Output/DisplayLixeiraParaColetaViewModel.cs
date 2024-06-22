using CidadeLimpa.Models;

namespace CidadeLimpa.ViewModels.Output
{
    public class DisplayLixeiraParaColetaViewModel
    {
        public int Id { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime DataLimite { get; set; }
        public bool Ativo { get; set; }
        public LixeiraModel Lixeira { get; set; }
    }
}
