using desafio_sistema_alvo.DTOs.Comissao;
using desafio_sistema_alvo.Models;

namespace desafio_sistema_alvo.Services.Interfaces;

public interface IComissaoService
{
    Task<List<Venda>> ObterVendasAsync();

    Task<List<ComissaoResponseDto>> CalcularComissaoAsync();
}