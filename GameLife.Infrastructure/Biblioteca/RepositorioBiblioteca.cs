using GameLife.Application.Biblioteca;
using GameLife.Domain.Biblioteca;
using GameLife.Domain.Jogos;
using GameLife.Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace GameLife.Infrastructure.Biblioteca;

public sealed class RepositorioBiblioteca(GameLifeDbContext contexto) : IRepositorioBiblioteca
{
    public Task<Jogo?> BuscarJogoPorTituloNormalizadoAsync(
        string tituloNormalizado,
        CancellationToken cancellationToken) =>
        contexto.Jogos.SingleOrDefaultAsync(
            jogo => jogo.TituloNormalizado == tituloNormalizado,
            cancellationToken);

    public Task<bool> ExisteItemAsync(
        Guid jogoId,
        string plataforma,
        CancellationToken cancellationToken) =>
        contexto.ItensBiblioteca.AnyAsync(
            item => item.JogoId == jogoId && item.Plataforma == plataforma,
            cancellationToken);

    public async Task AdicionarAsync(ItemBiblioteca item, CancellationToken cancellationToken)
    {
        contexto.ItensBiblioteca.Add(item);
        await contexto.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<ItemBiblioteca>> ListarAsync(
        CancellationToken cancellationToken) =>
        await contexto.ItensBiblioteca
            .AsNoTracking()
            .Include(item => item.Jogo)
            .OrderBy(item => item.Jogo.Titulo)
            .ThenBy(item => item.Plataforma)
            .ToListAsync(cancellationToken);
}
