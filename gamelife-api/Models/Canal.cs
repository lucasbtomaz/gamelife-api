namespace gamelife_api.Models
{
    public class Canal
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool PermitePosse { get; set; }
        public bool PermitePreco { get; set; }
    }
}
