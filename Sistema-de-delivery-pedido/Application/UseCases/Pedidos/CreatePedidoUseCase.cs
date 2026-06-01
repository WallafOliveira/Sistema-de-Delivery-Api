using System;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_delivery_pedido.Application.DTOs.Pedidos;
using Sistema_de_delivery_pedido.Domain.Entities;
using Sistema_de_delivery_pedido.Domain.Interfaces;

namespace Sistema_de_delivery_pedido.Application.UseCases.Pedidos
{
    public class CreatePedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public CreatePedidoUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<PedidoDto> Executar(CreatePedidoDto dto)
        {
            if (dto.Itens == null || dto.Itens.Count == 0)
                throw new ArgumentException("O pedido deve conter ao menos um item.");

            var pedido = new Pedido(dto.ClienteId, dto.RestauranteId);

            foreach (var itemDto in dto.Itens)
            {
                var item = new ItemPedido(pedido.Id, itemDto.ProdutoId, itemDto.NomeProduto, itemDto.Quantidade, itemDto.ValorUnitario);
                pedido.AdicionarItem(item);
            }

            await _pedidoRepository.Adicionar(pedido);

            return MapToDto(pedido);
        }

        private static PedidoDto MapToDto(Pedido pedido) => new()
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
