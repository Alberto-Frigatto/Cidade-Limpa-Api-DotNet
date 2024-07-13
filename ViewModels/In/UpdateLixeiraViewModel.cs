using System.ComponentModel.DataAnnotations;

namespace CidadeLimpa.ViewModels.In
{
    public class UpdateLixeiraViewModel
    {
        [Required(ErrorMessage = "A localização é obrigatória")]
        [MinLength(1, ErrorMessage = "A localização não pode ser vazia")]
        [MaxLength(100, ErrorMessage = "A localização não deve exceder 100 caracteres")]
        public string Localizacao { get; set; }

        [Required(ErrorMessage = "A capacidade é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A capacidade é inválida")]
        public int Capacidade { get; set; }

        [Required(ErrorMessage = "A Ocupação é obrigatória")]
        [Range(0.00, 1.00, ErrorMessage = "A Ocupação deve ser entre 0 e 1")]
        [RegularExpression(@"^(\d{1,1}(\.\d{0,2})?)$", ErrorMessage = "A Ocupação deve ter precisão de 3 e escala de 2")]
        public decimal Ocupacao { get; set; }
    }
}
