namespace GameLife.Application.Biblioteca;

public interface IServicoBiblioteca
{
    Task<ItemBibliotecaResposta> AdicionarAsync(
        AdicionarItemBibliotecaComando comando,
        CancellationToken cancellationToken);

    Task<IReadOnlyList<ItemBibliotecaResposta>> ListarAsync(CancellationToken cancellationToken);
}
