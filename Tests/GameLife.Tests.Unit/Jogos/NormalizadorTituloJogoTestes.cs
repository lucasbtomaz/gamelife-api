using GameLife.Domain.Jogos;

namespace GameLife.Tests.Unit.Jogos;

public class NormalizadorTituloJogoTestes
{
    [Theory]
    [InlineData("  The Last of Us  ", "the last of us")]
    [InlineData("The    Last\tof\nUs", "the last of us")]
    [InlineData("POKÉMON: Let's Go!", "pokemon let s go")]
    [InlineData("NieR:Automata™", "nier automata")]
    [InlineData("Resident Evil 2 Remake", "resident evil 2 remake")]
    [InlineData("Final Fantasy VII Remastered Deluxe", "final fantasy vii remastered deluxe")]
    public void Normalizar_DeveAplicarAsRegrasDoTitulo(string titulo, string resultadoEsperado)
    {
        var resultado = NormalizadorTituloJogo.Normalizar(titulo);

        Assert.Equal(resultadoEsperado, resultado);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("---")]
    public void Normalizar_QuandoNaoHouverLetrasOuNumeros_DeveRetornarVazio(string titulo)
    {
        var resultado = NormalizadorTituloJogo.Normalizar(titulo);

        Assert.Empty(resultado);
    }

    [Fact]
    public void Normalizar_QuandoTituloForNulo_DeveLancarExcecao()
    {
        Assert.Throws<ArgumentNullException>(() => NormalizadorTituloJogo.Normalizar(null!));
    }
}
