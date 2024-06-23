using System.ComponentModel.DataAnnotations;

namespace CidadeLimpa.ViewModels.In
{
    public class UpdateLixeiraParaColetaViewModel
    {
        [Required(ErrorMessage = "O novo status de Ativo é obrigatório")]
        public bool Ativo { get; set; }
    }
}
