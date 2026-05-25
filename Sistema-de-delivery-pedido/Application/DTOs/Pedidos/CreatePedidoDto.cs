namespace Sistema_de_delivery_pedido.Application.DTOs.Pedidos
{
    public class CreatePedidoDto
    {
        public Guid ClienteId { get; set; }
        public Guid RestauranteId { get; set; }
        public List<CreateItemPedidoDto> Itens { get; set; } = new();
    }
}
