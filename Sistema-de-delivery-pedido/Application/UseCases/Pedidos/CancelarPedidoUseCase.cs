using System;
using System.Threading.Tasks;
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

        public async Task Executar(Guid id)
        {
            var pedido = await _pedidoRepository.ObterPorId(id)
                ?? throw new Exception("Pedido não encontrado.");

            pedido.Cancelar();
            await _pedidoRepository.Atualizar(id, pedido);
        }
    }
}
