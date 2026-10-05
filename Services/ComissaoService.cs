using System.Text.Json;
using desafio_sistema_alvo.DTOs.Comissao;
using desafio_sistema_alvo.Models;
using desafio_sistema_alvo.Services.Interfaces;

namespace desafio_sistema_alvo.Services;

public class ComissaoService : IComissaoService
{
    private readonly IWebHostEnvironment _environment;

    public ComissaoService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<List<Venda>> ObterVendasAsync()
    {
        var caminhoArquivo = Path.Combine(
            _environment.ContentRootPath,
            "Data",
            "JsonData",
            "vendas.json"
        );

        if (!File.Exists(caminhoArquivo))
        {
            throw new FileNotFoundException(
                $"Arquivo de vendas não encontrado: {caminhoArquivo}"
            );
        }

        var json = await File.ReadAllTextAsync(caminhoArquivo);

        var dados = JsonSerializer.Deserialize<VendasData>(json);

        if (dados is null)
        {
            throw new InvalidOperationException(
                "Não foi possível desserializar o arquivo de vendas."
            );
        }

        return dados.Vendas;
    }

    public async Task<List<ComissaoResponseDto>> CalcularComissaoAsync()
    {
        var vendas = await ObterVendasAsync();

        return vendas
            .GroupBy(venda => venda.Vendedor)
            .Select(grupo =>
            {
                var totalVendas = grupo.Sum(venda => venda.Valor);

                var totalComissao = grupo.Sum(venda =>
                {
                    decimal comissao;

                    if (venda.Valor < 100)
                    {
                        comissao = 0m;
                    }
                    else if (venda.Valor < 500)
                    {
                        comissao = venda.Valor * 0.01m;
                    }
                    else
                    {
                        comissao = venda.Valor * 0.05m;
                    }

                    return Math.Round(
                        comissao,
                        2,
                        MidpointRounding.AwayFromZero
                    );
                });

                return new ComissaoResponseDto
                {
                    Vendedor = grupo.Key,
                    TotalVendas = totalVendas,
                    TotalComissao = totalComissao
                };
            })
            .ToList();
    }
}