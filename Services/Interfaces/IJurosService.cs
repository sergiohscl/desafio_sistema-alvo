namespace desafio_sistema_alvo.Services.Interfaces;

public interface IJurosService
{
    decimal CalcularJuros(decimal valor, DateTime dataVencimento);
}