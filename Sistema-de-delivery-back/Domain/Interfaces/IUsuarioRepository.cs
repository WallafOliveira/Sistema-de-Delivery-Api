using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sistema_de_delivery_back.Domain.Entities;

namespace Sistema_de_delivery_back.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Adicionar(Usuario usuario);
        Task<Usuario?> BuscarPorId(Guid id);
        Task<Usuario?> BuscarPorEmail(string email);
        Task<IEnumerable<Usuario>> ListarTodos();
        Task<Usuario?> Atualizar(Guid id, Usuario usuario);
        Task<bool> DeleteAsync(Guid id);
    }
}