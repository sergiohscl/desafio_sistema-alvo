namespace desafio_sistema_alvo.Models;

public class MovimentacaoEstoque
{
    public Guid Id { get; set; }

    public int CodigoProduto { get; set; }

    public string TipoMovimentacao { get; set; } = string.Empty;

    public int Quantidade { get; set; }

    public string Descricao { get; set; } = string.Empty;
}

public enum TipoMovimentacao
{
    Entrada,
    Saida
}