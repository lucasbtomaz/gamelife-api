namespace GameLife.Application.Biblioteca;

public sealed class ItemBibliotecaJaExisteException(string titulo, string plataforma)
    : InvalidOperationException($"O jogo '{titulo}' já está na biblioteca para a plataforma '{plataforma}'.");
