namespace CidadeLimpa.Models
{
    public class PontoColetaModel
    {
        public int Id { get; set; }
        public string? Ponto { get; set; }
        public int IdRota { get; set; }
        public RotaModel Rota { get; set; }
    }
}