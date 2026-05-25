using Sistema_de_delivery_pedido.Domain.Interfaces;

namespace Sistema_de_delivery_pedido.Application.UseCases.Pedidos
{
    public class CancelarPedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public CancelarPedidoUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public void Executar(Guid id)
        {
            var pedido = _pedidoRepository.ObterPorId(id)
                ?? throw new Exception("Pedido não encontrado.");

            pedido.Cancelar();
            _pedidoRepository.Atualizar(pedido);
        }
    }
}
