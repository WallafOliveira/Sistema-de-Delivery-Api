using DataApplications.Data;
using DataApplications.Entities;
using Microsoft.EntityFrameworkCore;
using Sistema_de_delivery_pedido.Domain.Interfaces;

namespace Sistema_de_delivery_pedido.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DeliveryDbContext _context;

        public PedidoRepository(DeliveryDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }

        public void Atualizar(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            _context.SaveChanges();
        }

        public Pedido? ObterPorId(Guid id)
        {
            return _context.Pedidos
                           .Include(p => p.Itens)
                           .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Pedido> ObterTodos()
        {
            return _context.Pedidos
                           .Include(p => p.Itens)
                           .ToList();
        }

        public IEnumerable<Pedido> ObterPorClienteId(Guid clienteId)
        {
            return _context.Pedidos
                           .Include(p => p.Itens)
                           .Where(p => p.ClienteId == clienteId)
                           .ToList();
        }

        public IEnumerable<Pedido> ObterPorRestauranteId(Guid restauranteId)
        {
            return _context.Pedidos
                           .Include(p => p.Itens)
                           .Where(p => p.RestauranteId == restauranteId)
                           .ToList();
        }
    }
}
