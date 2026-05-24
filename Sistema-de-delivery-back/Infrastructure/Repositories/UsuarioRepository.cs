using DataApplications.Data;
using DataApplications.Entities;
using Sistema_de_delivery_back.Domain.Interfaces;

namespace Sistema_de_delivery_back.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DeliveryDbContext _context;

    public UsuarioRepository(DeliveryDbContext context)
    {
        _context = context;
    }

    public void Adicionar(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    public void Atualizar(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        _context.SaveChanges();
    }

    public List<Usuario> ListarTodos()
    {
        return _context.Usuarios.ToList();
    }

    public Usuario? BuscarPorId(Guid id)
    {
        return _context.Usuarios.Find(id);
    }

    public Usuario? BuscarPorEmail(string email)
    {
        return _context.Usuarios.FirstOrDefault(u => u.Email == email);
    }
}
