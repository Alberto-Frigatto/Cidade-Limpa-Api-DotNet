namespace CidadeLimpa.Models
{
    public class CaminhaoModel
    {
        public int Id { get; set; }
        public string? Modelo { get; set; }
        public int Capacidade { get; set; }
        public string? Placa { get; set; }
        public int IdRota { get; set; }
        public RotaModel Rota { get; set; }
    }
}
