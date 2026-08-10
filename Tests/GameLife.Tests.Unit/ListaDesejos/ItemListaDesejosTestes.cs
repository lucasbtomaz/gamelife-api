using GameLife.Domain.Jogos;
using GameLife.Domain.ListaDesejos;

namespace GameLife.Tests.Unit.ListaDesejos;

public class ItemListaDesejosTestes
{
    [Fact]
    public void Criar_DeveRegistrarJogoPlataformaEData()
    {
        var jogo = Jogo.Criar("Silksong");
        var data = new DateTime(2026, 8, 5, 18, 0, 0, DateTimeKind.Utc);

        var item = ItemListaDesejos.Criar(jogo, "Xbox", data);

        Assert.Equal(jogo.Id, item.JogoId);
        Assert.Equal("Xbox", item.Plataforma);
        Assert.Equal(data, item.AdicionadoEmUtc);
    }
}
