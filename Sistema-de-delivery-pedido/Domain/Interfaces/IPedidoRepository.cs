using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sistema_de_delivery_pedido.Domain.Entities;

namespace Sistema_de_delivery_pedido.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<Pedido> Adicionar(Pedido pedido);
        Task<Pedido?> Atualizar(Guid id, Pedido pedido);
        Task<Pedido?> ObterPorId(Guid id);
        Task<IEnumerable<Pedido>> ObterTodos();
        Task<IEnumerable<Pedido>> ObterPorClienteId(Guid clienteId);
        Task<IEnumerable<Pedido>> ObterPorRestauranteId(Guid restauranteId);
    }
}
