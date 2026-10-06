namespace desafio_sistema_alvo.DTO.Estoque;

public class MovimentacaoEstoqueResponse
{
    public Guid IdMovimentacao { get; set; }

    public int CodigoProduto { get; set; }

    public string DescricaoProduto { get; set; } = string.Empty;

    public string TipoMovimentacao { get; set; } = string.Empty;

    public int QuantidadeMovimentada { get; set; }

    public int EstoqueFinal { get; set; }

    public string Descricao { get; set; } = string.Empty;
}