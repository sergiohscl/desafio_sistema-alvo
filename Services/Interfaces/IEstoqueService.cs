using desafio_sistema_alvo.DTO.Estoque;
using desafio_sistema_alvo.Models;

namespace desafio_sistema_alvo.Services.Interfaces;

public interface IEstoqueService
{
    Task<List<Produto>> ObterProdutosAsync();

    Task<MovimentacaoEstoqueResponse> MovimentarAsync(
        MovimentacaoEstoqueRequest request);
}