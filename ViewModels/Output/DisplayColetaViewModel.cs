using CidadeLimpa.Models;

namespace CidadeLimpa.ViewModels.Output
{
    public class DisplayColetaViewModel
    {
        public int Id { get; set; }
        public DisplayCaminhaoViewModel Caminhao { get; set; }
        public DisplayLixeiraViewModel Lixeira { get; set; }
        public string? DataColeta { get; set; }
    }
}
