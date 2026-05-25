namespace Sistema_de_delivery_pedido.Application.DTOs.Pedidos
{
    public class PedidoDto
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public Guid RestauranteId { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal ValorTotal { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<ItemPedidoDto> Itens { get; set; } = new();
    }
}
