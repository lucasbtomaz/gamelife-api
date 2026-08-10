using GameLife.Application.Biblioteca;
using Microsoft.AspNetCore.Mvc;

namespace GameLife.Api.Controllers;

[ApiController]
[Route("biblioteca")]
public sealed class BibliotecaController(IServicoBiblioteca servico) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType<ItemBibliotecaResposta>(StatusCodes.Status201Created)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<ItemBibliotecaResposta>> Adicionar(
        [FromBody] AdicionarItemBibliotecaRequisicao requisicao,
        CancellationToken cancellationToken)
    {
        try
        {
            var resposta = await servico.AdicionarAsync(
                new AdicionarItemBibliotecaComando(requisicao.Titulo, requisicao.Plataforma),
                cancellationToken);

            return Created("/biblioteca", resposta);
        }
        catch (ItemBibliotecaJaExisteException excecao)
        {
            return Conflict(new ProblemDetails
            {
                Title = "Jogo já cadastrado na biblioteca",
                Detail = excecao.Message,
                Status = StatusCodes.Status409Conflict
            });
        }
        catch (ArgumentException excecao)
        {
            return BadRequest(new ProblemDetails
            {
                Title = "Dados inválidos",
                Detail = excecao.Message,
                Status = StatusCodes.Status400BadRequest
            });
        }
    }

    [HttpGet]
    [ProducesResponseType<IReadOnlyList<ItemBibliotecaResposta>>(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ItemBibliotecaResposta>>> Listar(
        CancellationToken cancellationToken)
    {
        var resposta = await servico.ListarAsync(cancellationToken);
        return Ok(resposta);
    }
}

public sealed record AdicionarItemBibliotecaRequisicao(string Titulo, string Plataforma);
