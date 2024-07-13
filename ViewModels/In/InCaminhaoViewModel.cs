using System.ComponentModel.DataAnnotations;

namespace CidadeLimpa.ViewModels.In
{
    public class InCaminhaoViewModel
    {
        [Required(ErrorMessage = "O modelo é obrigatório")]
        [MinLength(1, ErrorMessage = "O modelo não pode ser vazio")]
        [MaxLength(50, ErrorMessage = "O modelo não deve exceder 50 caracteres")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A capacidade é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A capacidade é inválida")]
        public int Capacidade { get; set; }

        [Required(ErrorMessage = "A placa do caminhão é obrigatória")]
        [MinLength(7, ErrorMessage = "A palaca do caminhão deve ter 7 caracteres")]
        [MaxLength(7, ErrorMessage = "A palaca do caminhão deve ter 7 caracteres")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O id da rota é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id da rota é inválido")]
        public int IdRota { get; set; }
    }
}
