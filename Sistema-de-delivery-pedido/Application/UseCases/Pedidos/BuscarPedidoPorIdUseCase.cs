using System;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_delivery_pedido.Application.DTOs.Pedidos;
using Sistema_de_delivery_pedido.Domain.Interfaces;

namespace Sistema_de_delivery_pedido.Application.UseCases.Pedidos
{
    public class BuscarPedidoPorIdUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public BuscarPedidoPorIdUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<PedidoDto> Executar(Guid id)
        {
            var pedido = await _pedidoRepository.ObterPorId(id)
                ?? throw new Exception("Pedido não encontrado.");

            return new PedidoDto
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
            };
        }
    }
}
