namespace gamelife_api.Models
{
    public class RegistroJogo
    {
        public int Id { get; set; }
        public int PosseJogoId { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public decimal? TempoEmHoras { get; set; }
        public string? Dificuldade { get; set; }
        public int? ConquistasPossiveis { get; set; }
        public int? ConquistasObtidas { get; set; }

        public PosseJogo PosseJogo { get; set; } = null!;
    }
}
