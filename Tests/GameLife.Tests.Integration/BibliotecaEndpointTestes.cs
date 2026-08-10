using System.Net;
using System.Net.Http.Json;
using GameLife.Application.Biblioteca;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace GameLife.Tests.Integration;

public class BibliotecaEndpointTestes
{
    [Fact]
    public async Task PostBiblioteca_DeveRetornarItemCriado()
    {
        var servico = new ServicoBibliotecaEmMemoria();
        await using var fabrica = CriarFabrica(servico);
        var cliente = fabrica.CreateClient();

        var resposta = await cliente.PostAsJsonAsync("/biblioteca", new
        {
            titulo = "Hades",
            plataforma = "PC"
        });

        Assert.Equal(HttpStatusCode.Created, resposta.StatusCode);
        var item = await resposta.Content.ReadFromJsonAsync<ItemBibliotecaResposta>();
        Assert.NotNull(item);
        Assert.Equal("Hades", item.Titulo);
        Assert.Equal("PC", item.Plataforma);
    }

    [Fact]
    public async Task GetBiblioteca_DeveRetornarItensCadastrados()
    {
        var servico = new ServicoBibliotecaEmMemoria();
        await servico.AdicionarAsync(
            new AdicionarItemBibliotecaComando("Hades", "PC"),
            CancellationToken.None);

        await using var fabrica = CriarFabrica(servico);
        var cliente = fabrica.CreateClient();

        var resposta = await cliente.GetAsync("/biblioteca");

        Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
        var itens = await resposta.Content.ReadFromJsonAsync<ItemBibliotecaResposta[]>();
        Assert.NotNull(itens);
        Assert.Single(itens);
        Assert.Equal("Hades", itens[0].Titulo);
    }

    private static WebApplicationFactory<Program> CriarFabrica(IServicoBiblioteca servico) =>
        new WebApplicationFactory<Program>().WithWebHostBuilder(construtor =>
        {
            construtor.ConfigureLogging(logging => logging.ClearProviders());
            construtor.ConfigureTestServices(servicos =>
            {
                servicos.RemoveAll<IServicoBiblioteca>();
                servicos.AddSingleton(servico);
            });
        });

    private sealed class ServicoBibliotecaEmMemoria : IServicoBiblioteca
    {
        private readonly List<ItemBibliotecaResposta> _itens = [];

        public Task<ItemBibliotecaResposta> AdicionarAsync(
            AdicionarItemBibliotecaComando comando,
            CancellationToken cancellationToken)
        {
            var resposta = new ItemBibliotecaResposta(
                Guid.NewGuid(),
                Guid.NewGuid(),
                comando.Titulo,
                comando.Plataforma,
                DateTime.UtcNow);

            _itens.Add(resposta);
            return Task.FromResult(resposta);
        }

        public Task<IReadOnlyList<ItemBibliotecaResposta>> ListarAsync(
            CancellationToken cancellationToken) =>
            Task.FromResult<IReadOnlyList<ItemBibliotecaResposta>>(_itens);
    }
}
