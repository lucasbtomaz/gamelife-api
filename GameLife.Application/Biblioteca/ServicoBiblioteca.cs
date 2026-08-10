using GameLife.Domain.Biblioteca;
using GameLife.Domain.Jogos;

namespace GameLife.Application.Biblioteca;

public sealed class ServicoBiblioteca(
    IRepositorioBiblioteca repositorio,
    TimeProvider provedorTempo) : IServicoBiblioteca
{
    public async Task<ItemBibliotecaResposta> AdicionarAsync(
        AdicionarItemBibliotecaComando comando,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(comando);

        if (string.IsNullOrWhiteSpace(comando.Titulo))
        {
            throw new ArgumentException("O título é obrigatório.", nameof(comando));
        }

        if (string.IsNullOrWhiteSpace(comando.Plataforma))
        {
            throw new ArgumentException("A plataforma é obrigatória.", nameof(comando));
        }

        var tituloNormalizado = NormalizadorTituloJogo.Normalizar(comando.Titulo);
        var plataforma = comando.Plataforma.Trim();
        var jogo = await repositorio.BuscarJogoPorTituloNormalizadoAsync(
            tituloNormalizado,
            cancellationToken) ?? Jogo.Criar(comando.Titulo);

        if (await repositorio.ExisteItemAsync(jogo.Id, plataforma, cancellationToken))
        {
            throw new ItemBibliotecaJaExisteException(jogo.Titulo, plataforma);
        }

        var item = ItemBiblioteca.Criar(
            jogo,
            comando.Plataforma,
            provedorTempo.GetUtcNow().UtcDateTime);

        await repositorio.AdicionarAsync(item, cancellationToken);
        return Mapear(item);
    }

    public async Task<IReadOnlyList<ItemBibliotecaResposta>> ListarAsync(
        CancellationToken cancellationToken)
    {
        var itens = await repositorio.ListarAsync(cancellationToken);
        return itens.Select(Mapear).ToArray();
    }

    private static ItemBibliotecaResposta Mapear(ItemBiblioteca item) => new(
        item.Id,
        item.JogoId,
        item.Jogo.Titulo,
        item.Plataforma,
        item.AdicionadoEmUtc);
}
