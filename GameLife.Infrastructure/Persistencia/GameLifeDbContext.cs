using GameLife.Domain.Biblioteca;
using GameLife.Domain.Jogos;
using GameLife.Domain.ListaDesejos;
using Microsoft.EntityFrameworkCore;

namespace GameLife.Infrastructure.Persistencia;

public sealed class GameLifeDbContext(DbContextOptions<GameLifeDbContext> options)
    : DbContext(options)
{
    public DbSet<Jogo> Jogos => Set<Jogo>();
    public DbSet<ItemBiblioteca> ItensBiblioteca => Set<ItemBiblioteca>();
    public DbSet<ItemListaDesejos> ItensListaDesejos => Set<ItemListaDesejos>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameLifeDbContext).Assembly);
    }
}
