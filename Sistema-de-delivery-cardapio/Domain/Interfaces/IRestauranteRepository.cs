using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sistema_de_delivery_cardapio.Domain.Entities;

namespace Sistema_de_delivery_cardapio.Domain.Interfaces
{
    public interface IRestauranteRepository
    {
        Task<Restaurante> Adicionar(Restaurante restaurante);
        Task<Restaurante?> Atualizar(Guid id, Restaurante restaurante);
        Task<IEnumerable<Restaurante>> ListarTodos();
        Task<IEnumerable<Restaurante>> ListarAbertos();
        Task<Restaurante?> BuscarPorId(Guid id);
    }
}
