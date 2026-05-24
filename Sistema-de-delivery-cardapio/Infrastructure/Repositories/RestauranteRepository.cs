using DataApplications.Data;
using DataApplications.Entities;
using Sistema_de_delivery_cardapio.Domain.Interfaces;

namespace Sistema_de_delivery_cardapio.Infrastructure.Repositories;

public class RestauranteRepository : IRestauranteRepository
{
    private readonly DeliveryDbContext _context;

    public RestauranteRepository(DeliveryDbContext context)
    {
        _context = context;
    }

    public void Adicionar(Restaurante restaurante)
    {
        _context.Restaurantes.Add(restaurante);
        _context.SaveChanges();
    }

    public void Atualizar(Restaurante restaurante)
    {
        _context.Restaurantes.Update(restaurante);
        _context.SaveChanges();
    }

    public List<Restaurante> ListarTodos()
    {
        return _context.Restaurantes.ToList();
    }

    public List<Restaurante> ListarAbertos()
    {
        return _context.Restaurantes.Where(r => r.EstaAberto).ToList();
    }

    public Restaurante? BuscarPorId(Guid id)
    {
        return _context.Restaurantes.Find(id);
    }
}
