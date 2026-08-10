using GameLife.Domain.Biblioteca;
using GameLife.Domain.Jogos;

namespace GameLife.Tests.Unit.Biblioteca;

public class ItemBibliotecaTestes
{
    [Fact]
    public void Criar_DeveRegistrarJogoPlataformaEData()
    {
        var jogo = Jogo.Criar("Hades");
        var data = new DateTime(2026, 8, 5, 18, 0, 0, DateTimeKind.Utc);

        var item = ItemBiblioteca.Criar(jogo, "  PC  ", data);

        Assert.Equal(jogo.Id, item.JogoId);
        Assert.Same(jogo, item.Jogo);
        Assert.Equal("PC", item.Plataforma);
        Assert.Equal(data, item.AdicionadoEmUtc);
    }

    [Fact]
    public void Criar_QuandoDataNaoForUtc_DeveLancarExcecao()
    {
        var jogo = Jogo.Criar("Hades");

        Assert.Throws<ArgumentException>(() =>
            ItemBiblioteca.Criar(jogo, "PC", DateTime.Now));
    }
}
