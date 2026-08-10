using GameLife.Application.Biblioteca;
using GameLife.Infrastructure.Biblioteca;
using GameLife.Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GameLife.Infrastructure;

public static class InjecaoDependencias
{
    public static IServiceCollection AdicionarInfraestrutura(
        this IServiceCollection servicos,
        string conexaoBancoDados)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(conexaoBancoDados);

        servicos.AddDbContext<GameLifeDbContext>(opcoes =>
            opcoes.UseSqlServer(conexaoBancoDados));

        servicos.AddScoped<IRepositorioBiblioteca, RepositorioBiblioteca>();
        servicos.AddScoped<IServicoBiblioteca, ServicoBiblioteca>();
        servicos.AddSingleton(TimeProvider.System);

        return servicos;
    }
}
