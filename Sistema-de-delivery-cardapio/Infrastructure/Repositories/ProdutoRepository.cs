using DataApplications.Data;
using DataApplications.Entities;
using Sistema_de_delivery_cardapio.Domain.Interfaces;

namespace Sistema_de_delivery_cardapio.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DeliveryDbContext _context;

        public ProdutoRepository(DeliveryDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        public Produto? ObterPorId(Guid id)
        {
            return _context.Produtos.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _context.Produtos.ToList();
        }

        public IEnumerable<Produto> ObterPorRestauranteId(Guid restauranteId)
        {
            return _context.Produtos
                           .Where(p => p.RestauranteId == restauranteId)
                           .ToList();
        }
    }
}
