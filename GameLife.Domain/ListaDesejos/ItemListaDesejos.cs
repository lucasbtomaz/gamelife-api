using GameLife.Domain.Jogos;

namespace GameLife.Domain.ListaDesejos;

public sealed class ItemListaDesejos
{
    private ItemListaDesejos()
    {
    }

    private ItemListaDesejos(Jogo jogo, string plataforma, DateTime adicionadoEmUtc)
    {
        Id = Guid.NewGuid();
        Jogo = jogo;
        JogoId = jogo.Id;
        Plataforma = plataforma;
        AdicionadoEmUtc = adicionadoEmUtc;
    }

    public Guid Id { get; private set; }
    public Guid JogoId { get; private set; }
    public Jogo Jogo { get; private set; } = null!;
    public string Plataforma { get; private set; } = string.Empty;
    public DateTime AdicionadoEmUtc { get; private set; }

    public static ItemListaDesejos Criar(Jogo jogo, string plataforma, DateTime adicionadoEmUtc)
    {
        ArgumentNullException.ThrowIfNull(jogo);

        if (string.IsNullOrWhiteSpace(plataforma))
        {
            throw new ArgumentException("A plataforma é obrigatória.", nameof(plataforma));
        }

        if (adicionadoEmUtc.Kind != DateTimeKind.Utc)
        {
            throw new ArgumentException("A data deve estar em UTC.", nameof(adicionadoEmUtc));
        }

        return new ItemListaDesejos(jogo, plataforma.Trim(), adicionadoEmUtc);
    }
}
