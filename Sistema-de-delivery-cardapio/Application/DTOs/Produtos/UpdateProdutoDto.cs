namespace Sistema_de_delivery_cardapio.Application.DTOs.Produtos
{
    public class UpdateProdutoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
