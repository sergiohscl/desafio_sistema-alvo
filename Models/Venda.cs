using System.Text.Json.Serialization;

namespace desafio_sistema_alvo.Models;

public class Venda
{
    [JsonPropertyName("vendedor")]
    public string Vendedor { get; set; } = string.Empty;

    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }
}