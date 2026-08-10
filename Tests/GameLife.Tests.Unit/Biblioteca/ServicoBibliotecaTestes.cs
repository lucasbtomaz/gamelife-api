using GameLife.Application.Biblioteca;
using GameLife.Domain.Biblioteca;
using GameLife.Domain.Jogos;

namespace GameLife.Tests.Unit.Biblioteca;

public class ServicoBibliotecaTestes
{
    private static readonly DateTimeOffset Agora = new(
        2026, 8, 5, 18, 0, 0, TimeSpan.Zero);

    [Fact]
    public async Task Adicionar_TitulosNormalizadosIguais_DevemReutilizarJogo()
    {
        var repositorio = new RepositorioBibliotecaEmMemoria();
        var servico = new ServicoBiblioteca(repositorio, new ProvedorTempoFixo(Agora));

        var primeiro = await servico.AdicionarAsync(
            new AdicionarItemBibliotecaComando("Pokémon", "Switch"),
            CancellationToken.None);

        var segundo = await servico.AdicionarAsync(
            new AdicionarItemBibliotecaComando("  POKEMON  ", "3DS"),
            CancellationToken.None);

        Assert.Equal(primeiro.JogoId, segundo.JogoId);
        Assert.Equal(2, repositorio.Itens.Count);
    }

    [Fact]
    public async Task Adicionar_QuandoJogoEPlataformaJaExistirem_DeveRecusarDuplicidade()
    {
        var repositorio = new RepositorioBibliotecaEmMemoria();
        var servico = new ServicoBiblioteca(repositorio, new ProvedorTempoFixo(Agora));
        var comando = new AdicionarItemBibliotecaComando("Hades", "PC");
        await servico.AdicionarAsync(comando, CancellationToken.None);

        await Assert.ThrowsAsync<ItemBibliotecaJaExisteException>(() =>
            servico.AdicionarAsync(comando, CancellationToken.None));
    }

    private sealed class RepositorioBibliotecaEmMemoria : IRepositorioBiblioteca
    {
        public List<ItemBiblioteca> Itens { get; } = [];

        public Task<Jogo?> BuscarJogoPorTituloNormalizadoAsync(
            string tituloNormalizado,
            CancellationToken cancellationToken) =>
            Task.FromResult(Itens.Select(item => item.Jogo)
                .FirstOrDefault(jogo => jogo.TituloNormalizado == tituloNormalizado));

        public Task<bool> ExisteItemAsync(
            Guid jogoId,
            string plataforma,
            CancellationToken cancellationToken) =>
            Task.FromResult(Itens.Any(item =>
                item.JogoId == jogoId && item.Plataforma == plataforma));

        public Task AdicionarAsync(ItemBiblioteca item, CancellationToken cancellationToken)
        {
            Itens.Add(item);
            return Task.CompletedTask;
        }

        public Task<IReadOnlyList<ItemBiblioteca>> ListarAsync(
            CancellationToken cancellationToken) =>
            Task.FromResult<IReadOnlyList<ItemBiblioteca>>(Itens);
    }

    private sealed class ProvedorTempoFixo(DateTimeOffset agora) : TimeProvider
    {
        public override DateTimeOffset GetUtcNow() => agora;
    }
}
