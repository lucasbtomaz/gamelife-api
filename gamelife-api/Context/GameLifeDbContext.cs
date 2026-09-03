using gamelife_api.Models;
using Microsoft.EntityFrameworkCore;

namespace gamelife_api.Context
{
    public class GameLifeDbContext : DbContext
    {
        public GameLifeDbContext(DbContextOptions<GameLifeDbContext> options) : base(options)
        {

        }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Canal> Canais { get; set; }
        public DbSet<PosseJogo> PossesJogos { get; set; }
        public DbSet<ItemListaDesejos> ItensListaDesejos { get; set; }
        public DbSet<MotivoDesejo> MotivosDesejos { get; set; }
        public DbSet<RegistroPreco> RegistrosPrecos { get; set; }
        public DbSet<RegistroJogo> RegistrosJogos { get; set; }

    }
}