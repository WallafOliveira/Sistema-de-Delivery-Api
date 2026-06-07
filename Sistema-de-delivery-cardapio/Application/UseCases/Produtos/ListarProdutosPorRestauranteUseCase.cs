using Sistema_de_delivery_cardapio.Application.DTOs.Produtos;
using Sistema_de_delivery_cardapio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_delivery_cardapio.Application.UseCases.Produtos
{
    public class ListarProdutosPorRestauranteUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ListarProdutosPorRestauranteUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<ProdutoDto>> Executar(Guid restauranteId)
        {
            var produtos = await _produtoRepository.ObterPorRestauranteId(restauranteId);

            return produtos.Select(p => new ProdutoDto
            {
                Id = p.Id,
                RestauranteId = p.RestauranteId,
                Nome = p.Nome,
                ImagemProduto = p.ImagemProduto,
                Quantidade = p.Quantidade,
                Valor = p.Valor
            });
        }
    }
}