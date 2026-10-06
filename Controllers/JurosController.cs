using desafio_sistema_alvo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace desafio_sistema_alvo.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class JurosController : ControllerBase
{
    private readonly IJurosService _jurosService;

    public JurosController(IJurosService jurosService)
    {
        _jurosService = jurosService;
    }

    [HttpGet]
    public ActionResult<decimal> CalcularJuros(
        [FromQuery] decimal valor,
        [FromQuery] DateTime dataVencimento)
    {
        var juros = _jurosService.CalcularJuros(
            valor,
            dataVencimento
        );

        return Ok(juros);
    }
}