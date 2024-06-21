namespace CidadeLimpa.Models
{
    public class LixeiraParaColetaModel
    {
        public int Id { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime DataLimite { get; set; }
        public bool Ativo { get; set; }
        public int IdLixeira { get; set; }
        public LixeiraModel Lixeira { get; set; }
    }
}
