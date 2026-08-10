using GameLife.Domain.Biblioteca;
using GameLife.Domain.Jogos;

namespace GameLife.Application.Biblioteca;

public interface IRepositorioBiblioteca
{
    Task<Jogo?> BuscarJogoPorTituloNormalizadoAsync(
        string tituloNormalizado,
        CancellationToken cancellationToken);

    Task<bool> ExisteItemAsync(
        Guid jogoId,
        string plataforma,
        CancellationToken cancellationToken);

    Task AdicionarAsync(ItemBiblioteca item, CancellationToken cancellationToken);

    Task<IReadOnlyList<ItemBiblioteca>> ListarAsync(CancellationToken cancellationToken);
}
