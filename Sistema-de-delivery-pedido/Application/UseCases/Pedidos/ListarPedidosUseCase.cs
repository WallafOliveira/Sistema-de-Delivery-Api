using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_delivery_pedido.Application.DTOs.Pedidos;
using Sistema_de_delivery_pedido.Domain.Interfaces;

namespace Sistema_de_delivery_pedido.Application.UseCases.Pedidos
{
    public class ListarPedidosUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public ListarPedidosUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<IEnumerable<PedidoDto>> Executar()
        {
            var pedidos = await _pedidoRepository.ObterTodos();

            return pedidos.Select(pedido => new PedidoDto
            {
                Id = pedido.Id,
                ClienteId = pedido.ClienteId,
                RestauranteId = pedido.RestauranteId,
                Status = pedido.Status,
                ValorTotal = pedido.ValorTotal,
                DataCriacao = pedido.DataCriacao,
                Itens = pedido.Itens.Select(i => new ItemPedidoDto
                {
                    Id = i.Id,
                    ProdutoId = i.ProdutoId,
                    NomeProduto = i.NomeProduto,
                    Quantidade = i.Quantidade,
                    ValorUnitario = i.ValorUnitario,
                    ValorTotal = i.ValorTotal
                }).ToList()
            });
        }
    }
}
