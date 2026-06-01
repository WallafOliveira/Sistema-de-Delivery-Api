using System;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<PedidoDto> Executar(UpdatePedidoStatusDto dto)
        {
            if (!StatusValidos.Contains(dto.Status))
                throw new ArgumentException($"Status inválido. Valores aceitos: {string.Join(", ", StatusValidos)}");

            var pedido = await _pedidoRepository.ObterPorId(dto.Id)
                ?? throw new Exception("Pedido não encontrado.");

            pedido.AtualizarStatus(dto.Status);

            var pedidoAtualizado = await _pedidoRepository.Atualizar(dto.Id, pedido);

            if (pedidoAtualizado == null)
                throw new Exception("Falha ao atualizar pedido.");

            return new PedidoDto
            {
                Id = pedidoAtualizado.Id,
                ClienteId = pedidoAtualizado.ClienteId,
                RestauranteId = pedidoAtualizado.RestauranteId,
                Status = pedidoAtualizado.Status,
                ValorTotal = pedidoAtualizado.ValorTotal,
                DataCriacao = pedidoAtualizado.DataCriacao,
                Itens = pedidoAtualizado.Itens.Select(i => new ItemPedidoDto
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
