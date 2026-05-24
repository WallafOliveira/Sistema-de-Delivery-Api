using Sistema_de_delivery_cardapio.Application.DTOs.Produtos;
using Sistema_de_delivery_cardapio.Domain.Interfaces;

namespace Sistema_de_delivery_cardapio.Application.UseCases.Produtos
{
    public class UpdateProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public UpdateProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public ProdutoDto Executar(UpdateProdutoDto dto)
        {
            var produto = _produtoRepository.ObterPorId(dto.Id);

            if (produto == null)
                throw new Exception("Produto não encontrado.");

            produto.AtualizarDetalhes(dto.Nome, dto.Quantidade, dto.Valor);

            _produtoRepository.Atualizar(produto);

            return new ProdutoDto
            {
                Id = produto.Id,
                RestauranteId = produto.RestauranteId,
                Nome = produto.Nome,
                Quantidade = produto.Quantidade,
                Valor = produto.Valor
            };
        }
    }
}
