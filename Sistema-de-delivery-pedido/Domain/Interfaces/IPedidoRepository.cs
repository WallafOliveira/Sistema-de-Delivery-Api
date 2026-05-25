using DataApplications.Entities;

namespace Sistema_de_delivery_pedido.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        void Adicionar(Pedido pedido);
        void Atualizar(Pedido pedido);
        Pedido? ObterPorId(Guid id);
        IEnumerable<Pedido> ObterTodos();
        IEnumerable<Pedido> ObterPorClienteId(Guid clienteId);
        IEnumerable<Pedido> ObterPorRestauranteId(Guid restauranteId);
    }
}
