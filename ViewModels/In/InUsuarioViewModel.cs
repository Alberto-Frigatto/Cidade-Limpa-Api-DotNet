using System.ComponentModel.DataAnnotations;

namespace CidadeLimpa.ViewModels.In
{
    public class InUsuarioViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        [MinLength(1, ErrorMessage = "O email não pode ser vazio")]
        [MaxLength(100, ErrorMessage = "O email não deve exceder 100 caracteres")]
        [EmailAddress(ErrorMessage = "O email deve ser um endereço válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MinLength(1, ErrorMessage = "A senha não pode ser vazia")]
        [MaxLength(255, ErrorMessage = "A senha não deve exceder 255 caracteres")]
        public string Senha { get; set; }
    }
}
