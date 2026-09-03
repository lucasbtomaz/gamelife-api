namespace gamelife_api.Models
{
    public class PosseJogo
    {
        public int Id { get; set; }
        public int JogoId { get; set; }
        public int CanalId { get; set; }
        public DateTime? AdquiridoEm { get; set; }

        public Jogo Jogo { get; set; } = null!;
        public Canal Canal { get; set; } = null!;
    }
}
