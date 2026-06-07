namespace Sistema_de_delivery_cardapio.Application.DTOs.Produtos
{
    public class ProdutoDto
    {
    public Guid Id { get; set; }
    public Guid RestauranteId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? ImagemProduto { get; set; }
    public int Quantidade { get; set; }
    public decimal Valor { get; set; }
    }
}
