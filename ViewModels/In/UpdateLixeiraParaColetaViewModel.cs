using System.ComponentModel.DataAnnotations;

namespace CidadeLimpa.ViewModels.In
{
    public class UpdateLixeiraParaColetaViewModel
    {
        [Required(ErrorMessage = "O id da lixeira para coleta é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O id da lixeira para coleta é inválido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O novo status de Ativo é obrigatório")]
        public bool Ativo { get; set; }
    }
}
