using System.ComponentModel.DataAnnotations;

namespace CidadeLimpa.ViewModels.In
{
    public class InColetaViewModel
    {
        [Required(ErrorMessage = "O id do caminhão é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id do caminhão é inválido")]
        public int IdCaminhao { get; set; }

        [Required(ErrorMessage = "O id da lixeira é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id da lixeira é inválido")]
        public int IdLixeira { get; set; }
    }
}
