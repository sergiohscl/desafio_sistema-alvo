using desafio_sistema_alvo.DTOs.Comissao;
using desafio_sistema_alvo.Models;
using desafio_sistema_alvo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace desafio_sistema_alvo.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ComissaoController : ControllerBase
{
    private readonly IComissaoService _comissaoService;

    public ComissaoController(IComissaoService comissaoService)
    {
        _comissaoService = comissaoService;
    }

    [HttpGet("vendas")]
    public async Task<ActionResult<List<Venda>>> ObterVendas()
    {
        var vendas = await _comissaoService.ObterVendasAsync();

        return Ok(vendas);
    }

    [HttpGet]
    public async Task<ActionResult<List<ComissaoResponseDto>>> ObterComissoes()
    {
        var comissoes = await _comissaoService.CalcularComissaoAsync();

        return Ok(comissoes);
    }
}