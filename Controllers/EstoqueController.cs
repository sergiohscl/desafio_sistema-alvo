using desafio_sistema_alvo.DTO.Estoque;
using desafio_sistema_alvo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace desafio_sistema_alvo.Controllers;

[ApiController]
[Route("api/v1/estoque")]
public class EstoqueController : ControllerBase
{
    private readonly IEstoqueService _estoqueService;

    public EstoqueController(IEstoqueService estoqueService)
    {
        _estoqueService = estoqueService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterProdutos()
    {
        var produtos = await _estoqueService.ObterProdutosAsync();

        return Ok(produtos);
    }

    [HttpPost("movimentar")]
    public async Task<IActionResult> Movimentar(
        [FromBody] MovimentacaoEstoqueRequest request)
    {
        var resultado = await _estoqueService.MovimentarAsync(request);

        return Ok(resultado);
    }
}