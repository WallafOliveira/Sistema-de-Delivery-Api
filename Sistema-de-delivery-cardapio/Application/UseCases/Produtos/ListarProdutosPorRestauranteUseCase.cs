using Sistema_de_delivery_cardapio.Application.DTOs.Produtos;
using Sistema_de_delivery_cardapio.Domain.Interfaces;

namespace Sistema_de_delivery_cardapio.Application.UseCases.Produtos
{
    public class ListarProdutosPorRestauranteUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ListarProdutosPorRestauranteUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<ProdutoDto> Executar(Guid restauranteId)
        {
            var produtos = _produtoRepository.ObterPorRestauranteId(restauranteId);

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
