using Sistema_de_delivery_cardapio.Application.DTOs.Produtos;
using Sistema_de_delivery_cardapio.Domain.Interfaces;

namespace Sistema_de_delivery_cardapio.Application.UseCases.Produtos
{
    public class ListarProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ListarProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<ProdutoDto> Executar()
        {
            var produtos = _produtoRepository.ObterTodos();

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
