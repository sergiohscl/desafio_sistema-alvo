using System.Text.Json;
using desafio_sistema_alvo.DTO.Estoque;
using desafio_sistema_alvo.Models;
using desafio_sistema_alvo.Services.Interfaces;

namespace desafio_sistema_alvo.Services;

public class EstoqueService : IEstoqueService
{
    private readonly IWebHostEnvironment _environment;

    public EstoqueService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<List<Produto>> ObterProdutosAsync()
    {
        var caminhoArquivo = Path.Combine(
            _environment.ContentRootPath,
            "Data",
            "JsonData",
            "estoque.json");

        if (!File.Exists(caminhoArquivo))
        {
            throw new FileNotFoundException(
                "Arquivo de estoque não encontrado.");
        }

        var json = await File.ReadAllTextAsync(caminhoArquivo);

        var dados = JsonSerializer.Deserialize<EstoqueArquivo>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        return dados?.Estoque ?? new List<Produto>();
    }

    public async Task<MovimentacaoEstoqueResponse> MovimentarAsync(
        MovimentacaoEstoqueRequest request)
    {
        if (request.Quantidade <= 0)
        {
            throw new ArgumentException(
                "A quantidade deve ser maior que zero.");
        }

        if (string.IsNullOrWhiteSpace(request.TipoMovimentacao))
        {
            throw new ArgumentException(
                "O tipo da movimentação deve ser informado.");
        }

        var produtos = await ObterProdutosAsync();

        var produto = produtos.FirstOrDefault(
            p => p.CodigoProduto == request.CodigoProduto);

        if (produto is null)
        {
            throw new KeyNotFoundException(
                "Produto não encontrado.");
        }

        if (!Enum.TryParse<TipoMovimentacao>(
                request.TipoMovimentacao,
                true,
                out var tipo))
        {
            throw new ArgumentException(
                "Tipo de movimentação inválido. " +
                "Informe Entrada ou Saida.");
        }

        if (tipo == TipoMovimentacao.Saida &&
            produto.Estoque < request.Quantidade)
        {
            throw new InvalidOperationException(
                "Estoque insuficiente para realizar a movimentação.");
        }

        if (tipo == TipoMovimentacao.Entrada)
        {
            produto.Estoque += request.Quantidade;
        }
        else
        {
            produto.Estoque -= request.Quantidade;
        }

        var caminhoArquivo = Path.Combine(
            _environment.ContentRootPath,
            "Data",
            "JsonData",
            "estoque.json");

        var dadosAtualizados = new EstoqueArquivo
        {
            Estoque = produtos
        };

        var jsonAtualizado = JsonSerializer.Serialize(
            dadosAtualizados,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        await File.WriteAllTextAsync(
            caminhoArquivo,
            jsonAtualizado);

        var movimentacao = new MovimentacaoEstoque
        {
            Id = Guid.NewGuid(),
            CodigoProduto = produto.CodigoProduto,
            TipoMovimentacao = tipo.ToString(),
            Quantidade = request.Quantidade,
            Descricao = request.Descricao
        };

        return new MovimentacaoEstoqueResponse
        {
            IdMovimentacao = movimentacao.Id,
            CodigoProduto = produto.CodigoProduto,
            DescricaoProduto = produto.DescricaoProduto,
            TipoMovimentacao = movimentacao.TipoMovimentacao,
            QuantidadeMovimentada = movimentacao.Quantidade,
            EstoqueFinal = produto.Estoque,
            Descricao = movimentacao.Descricao
        };
    }

    private class EstoqueArquivo
    {
        public List<Produto> Estoque { get; set; } = new();
    }
}