namespace Sistema_de_delivery_pedido.Application.DTOs.Pedidos
{
    public class UpdatePedidoStatusDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
