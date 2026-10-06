using desafio_sistema_alvo.Services.Interfaces;

namespace desafio_sistema_alvo.Services;

public class JurosService : IJurosService
{
    private const decimal PercentualJurosDiario = 0.025m;

    public decimal CalcularJuros(decimal valor, DateTime dataVencimento)
    {
        var hoje = DateTime.Today;

        if (dataVencimento >= hoje)
        {
            return 0;
        }

        var diasAtraso = (hoje - dataVencimento).Days;

        var juros = valor * PercentualJurosDiario * diasAtraso;

        return juros;
    }
}