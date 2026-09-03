namespace gamelife_api.Models
{
    public class Jogo
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int? AnoLancamento { get; set; }
    }
}
