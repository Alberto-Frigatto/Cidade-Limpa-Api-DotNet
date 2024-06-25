using CidadeLimpa.Models;

namespace CidadeLimpa.ViewModels.Output
{
    public class DisplayCaminhaoViewModel
    {
        public int Id { get; set; }
        public string? Modelo { get; set; }
        public int Capacidade { get; set; }
        public string? Placa { get; set; }
        public DisplayRotaViewModel Rota { get; set; }
    }
}
