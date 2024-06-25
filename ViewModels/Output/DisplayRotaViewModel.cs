using CidadeLimpa.Models;

namespace CidadeLimpa.ViewModels.Output
{
    public class DisplayRotaViewModel
    {
        public int Id { get; set; }
        public string? HorarioInicio { get; set; }
        public string? HorarioFim { get; set; }
        public ICollection<DisplayPontoColetaViewModel> ListaPontosColeta { get; set; }
    }
}
