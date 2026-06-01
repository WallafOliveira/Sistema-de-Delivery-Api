using Sistema_de_delivery_cardapio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema_de_delivery_cardapio.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> Adicionar(Produto produto);
        Task<Produto?> Atualizar(Guid id, Produto produto);
        Task<Produto?> ObterPorId(Guid id);
        Task<IEnumerable<Produto>> ObterTodos();
        Task<IEnumerable<Produto>> ObterPorRestauranteId(Guid restauranteId);
    }
}