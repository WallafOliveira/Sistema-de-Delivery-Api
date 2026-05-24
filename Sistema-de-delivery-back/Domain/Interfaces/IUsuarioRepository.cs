using DataApplications.Entities;

namespace Sistema_de_delivery_back.Domain.Interfaces;

public interface IUsuarioRepository
{
    void Adicionar(Usuario usuario);
    void Atualizar(Usuario usuario);
    List<Usuario> ListarTodos();
    Usuario? BuscarPorId(Guid id);
    Usuario? BuscarPorEmail(string email);
}
