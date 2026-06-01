using Sistema_de_delivery_cardapio.Application.DTOs.Produtos;
using Sistema_de_delivery_cardapio.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_delivery_cardapio.Application.UseCases.Produtos
{
    public class ListarProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ListarProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<ProdutoDto>> Executar()
        {
            var produtos = await _produtoRepository.ObterTodos();

            return produtos.Select(p => new ProdutoDto
            {
                Id = p.Id,
                RestauranteId = p.RestauranteId,
                Nome = p.Nome,
                Quantidade = p.Quantidade,
                Valor = p.Valor
            });
        }
    }
}