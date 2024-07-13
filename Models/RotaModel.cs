namespace CidadeLimpa.Models
{
    public class RotaModel
    {
        public int Id { get; set; }
        public string? HorarioInicio { get; set; }
        public string? HorarioFim { get; set; }
        public ICollection<PontoColetaModel>? ListaPontosColeta { get; set; }
    }
}