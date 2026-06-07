namespace Sistema_de_delivery_cardapio.Application.DTOs.Restaurantes;

public class RestauranteDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CPNJ { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public string? Logo { get; set; }
    public bool EstaAberto { get; set; }
}
