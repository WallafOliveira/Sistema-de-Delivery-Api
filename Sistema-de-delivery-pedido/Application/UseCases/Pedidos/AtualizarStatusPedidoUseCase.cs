using Sistema_de_delivery_pedido.Application.DTOs.Pedidos;
using Sistema_de_delivery_pedido.Domain.Interfaces;

namespace Sistema_de_delivery_pedido.Application.UseCases.Pedidos
{
    public class AtualizarStatusPedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;

        private static readonly string[] StatusValidos = ["Pendente", "Confirmado", "EmPreparo", "EmEntrega", "Entregue", "Cancelado"];

        public AtualizarStatusPedidoUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public PedidoDto Executar(UpdatePedidoStatusDto dto)
        {
            if (!StatusValidos.Contains(dto.Status))
                throw new ArgumentException($"Status inválido. Valores aceitos: {string.Join(", ", StatusValidos)}");

            var pedido = _pedidoRepository.ObterPorId(dto.Id)
                ?? throw new Exception("Pedido não encontrado.");

            pedido.AtualizarStatus(dto.Status);
            _pedidoRepository.Atualizar(pedido);

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
