using CidadeLimpa.Models;
using System.ComponentModel.DataAnnotations;

namespace CidadeLimpa.ViewModels.In
{
    public class InRotaViewModel
    {
        [Required(ErrorMessage = "O horário inicial é obrigatório")]
        [MinLength(5, ErrorMessage = "O horário inicial não ser menor que 5 caracteres")]
        [MaxLength(5, ErrorMessage = "O horário inicial não pode exceder 5 caracteres")]
        public string HorarioInicio { get; set; }

        [Required(ErrorMessage = "O horário final é obrigatório")]
        [MinLength(5, ErrorMessage = "O horário final deve ter 5 caracteres")]
        [MaxLength(5, ErrorMessage = "O horário final deve ter 5 caracteres")]
        public string HorarioFim { get; set; }

        [Required(ErrorMessage = "A lista de pontos de coleta é obrigatória")]
        public ICollection<string> ListaPontosColeta { get; set; } 
    }
}
