namespace GameLife.Domain.Jogos;

public sealed class Jogo
{
    private Jogo()
    {
    }

    private Jogo(string titulo, string tituloNormalizado)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        TituloNormalizado = tituloNormalizado;
    }

    public Guid Id { get; private set; }
    public string Titulo { get; private set; } = string.Empty;
    public string TituloNormalizado { get; private set; } = string.Empty;

    public static Jogo Criar(string titulo)
    {
        ArgumentNullException.ThrowIfNull(titulo);

        var tituloOriginal = titulo.Trim();
        var tituloNormalizado = NormalizadorTituloJogo.Normalizar(tituloOriginal);

        if (tituloNormalizado.Length == 0)
        {
            throw new ArgumentException("O título deve conter letras ou números.", nameof(titulo));
        }

        return new Jogo(tituloOriginal, tituloNormalizado);
    }
}
