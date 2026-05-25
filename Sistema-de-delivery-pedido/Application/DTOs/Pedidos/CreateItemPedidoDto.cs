namespace Sistema_de_delivery_pedido.Application.DTOs.Pedidos
{
    public class CreateItemPedidoDto
    {
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
    }
}
