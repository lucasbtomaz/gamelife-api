namespace GameLife.Application.Biblioteca;

public sealed record ItemBibliotecaResposta(
    Guid Id,
    Guid JogoId,
    string Titulo,
    string Plataforma,
    DateTime AdicionadoEmUtc);
