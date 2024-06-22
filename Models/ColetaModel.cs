namespace CidadeLimpa.Models
{
    public class ColetaModel
    {
        public int Id { get; set; }
        public int IdCaminhao { get; set; }
        public CaminhaoModel Caminhao { get; set; }
        public int IdLixeira { get; set; }
        public LixeiraModel Lixeira { get; set; }
        public string? DataColeta { get; set; }
    }
}
