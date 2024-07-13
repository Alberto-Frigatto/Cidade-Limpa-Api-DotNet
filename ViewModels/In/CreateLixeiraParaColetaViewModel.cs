using System.ComponentModel.DataAnnotations;

namespace CidadeLimpa.ViewModels.In
{
    public class CreateLixeiraParaColetaViewModel
    {
        [Required(ErrorMessage = "O id da lixeira é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id da lixeira é inválido")]
        public int IdLixeira { get; set; }
    }
}
