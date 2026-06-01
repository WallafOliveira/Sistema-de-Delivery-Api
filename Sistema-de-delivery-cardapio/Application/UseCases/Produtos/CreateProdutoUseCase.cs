using Sistema_de_delivery_cardapio.Application.DTOs.Produtos;
using Sistema_de_delivery_cardapio.Domain.Entities;
using Sistema_de_delivery_cardapio.Domain.Interfaces;
using System.Threading.Tasks;

namespace Sistema_de_delivery_cardapio.Application.UseCases.Produtos
{
    public class CreateProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public CreateProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ProdutoDto> Executar(CreateProdutoDto dto)
        {
            var produto = new Produto(dto.RestauranteId, dto.Nome, dto.Quantidade, dto.Valor);

            await _produtoRepository.Adicionar(produto);

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