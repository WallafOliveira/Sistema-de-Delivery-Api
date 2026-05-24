namespace Sistema_de_delivery_cardapio.Application.DTOs.Restaurantes;

public class UpdateRestauranteDto
{
    public string Nome { get; set; } = string.Empty;
    public string CPNJ { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public bool EstaAberto { get; set; }
}
