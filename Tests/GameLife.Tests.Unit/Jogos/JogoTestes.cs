using GameLife.Domain.Jogos;

namespace GameLife.Tests.Unit.Jogos;

public class JogoTestes
{
    [Fact]
    public void Criar_DevePreservarTituloOriginalENormalizarComparacao()
    {
        var jogo = Jogo.Criar("  Pokémon: Let's Go!  ");

        Assert.Equal("Pokémon: Let's Go!", jogo.Titulo);
        Assert.Equal("pokemon let s go", jogo.TituloNormalizado);
        Assert.NotEqual(Guid.Empty, jogo.Id);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("---")]
    public void Criar_QuandoTituloForInvalido_DeveLancarExcecao(string titulo)
    {
        Assert.Throws<ArgumentException>(() => Jogo.Criar(titulo));
    }
}
