using CidadeLimpa.Models;

namespace CidadeLimpa.ViewModels.Output
{
    public class DisplayColetaViewModel
    {
        public int Id { get; set; }
        public CaminhaoModel Caminhao { get; set; }
        public LixeiraModel Lixeira { get; set; }
        public string? DataColeta { get; set; }
    }
}
