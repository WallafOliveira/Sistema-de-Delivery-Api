using DataApplications.Entities;
using Sistema_de_delivery_cardapio.Application.DTOs.Produtos;
using Sistema_de_delivery_cardapio.Domain.Interfaces;

namespace Sistema_de_delivery_cardapio.Application.UseCases.Produtos
{
    public class CreateProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public CreateProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public ProdutoDto Executar(CreateProdutoDto dto)
        {
            var produto = new Produto(dto.RestauranteId, dto.Nome, dto.Quantidade, dto.Valor);

            _produtoRepository.Adicionar(produto);

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
