namespace gamelife_api.Models
{
    public class RegistroPreco
    {
        public int Id { get; set; }
        public int ItemListaDesejosId { get; set; }
        public int CanalId { get; set; }
        public decimal PrecoCheio { get; set; }
        public decimal PrecoAtual { get; set; }
        public bool Disponivel { get; set; }
        public DateTime ConsultadoEm { get; set; }

        public ItemListaDesejos ItemListaDesejos { get; set; } = null!;
        public Canal Canal { get; set; } = null!;
    }
}
