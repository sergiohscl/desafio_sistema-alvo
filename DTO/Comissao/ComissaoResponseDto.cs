namespace desafio_sistema_alvo.DTOs.Comissao;

public class ComissaoResponseDto
{
    public string Vendedor { get; set; } = string.Empty;

    public decimal TotalVendas { get; set; }

    public decimal TotalComissao { get; set; }
}