namespace gamelife_api.Models
{
    public class ItemListaDesejos
    {
        public int Id { get; set; }
        public int JogoId { get; set; }
        public string? Observacao { get; set; }
        public decimal? PrecoDesejado { get; set; }
        public DateTime CriadoEm { get; set; }

        public Jogo Jogo { get; set; } = null!;
        public List<MotivoDesejo> Motivos { get; set; } = [];
    }
}
