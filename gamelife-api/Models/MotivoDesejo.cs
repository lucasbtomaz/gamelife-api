namespace gamelife_api.Models
{
    public class MotivoDesejo
    {
        public int Id { get; set; }
        public int ItemListaDesejosId { get; set; }
        public string Descricao { get; set; } = string.Empty;

        public ItemListaDesejos ItemListaDesejos { get; set; } = null!;
    }
}
