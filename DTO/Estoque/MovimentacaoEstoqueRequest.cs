namespace desafio_sistema_alvo.DTO.Estoque;

public class MovimentacaoEstoqueRequest
{
    public int CodigoProduto { get; set; }

    public string TipoMovimentacao { get; set; } = string.Empty;

    public int Quantidade { get; set; }

    public string Descricao { get; set; } = string.Empty;
}