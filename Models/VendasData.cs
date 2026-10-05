using System.Text.Json.Serialization;

namespace desafio_sistema_alvo.Models;

public class VendasData
{
    [JsonPropertyName("vendas")]
    public List<Venda> Vendas { get; set; } = [];
}