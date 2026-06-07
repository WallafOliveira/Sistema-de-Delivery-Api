using Sistema_de_delivery_cardapio.Application.DTOs.Produtos;
using Sistema_de_delivery_cardapio.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Sistema_de_delivery_cardapio.Application.UseCases.Produtos
{
    public class UpdateProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public UpdateProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ProdutoDto> Executar(UpdateProdutoDto dto)
        {
            var produto = await _produtoRepository.ObterPorId(dto.Id);

            if (produto == null)
                throw new Exception("Produto não encontrado.");

            produto.AtualizarDetalhes(dto.Nome, dto.Quantidade, dto.Valor, dto.ImagemProduto);

            var produtoAtualizado = await _produtoRepository.Atualizar(dto.Id, produto);

            if (produtoAtualizado == null)
                throw new Exception("Falha ao atualizar produto.");

            return new ProdutoDto
            {
                Id = produtoAtualizado.Id,
                RestauranteId = produtoAtualizado.RestauranteId,
                Nome = produtoAtualizado.Nome,
                ImagemProduto = produtoAtualizado.ImagemProduto,
                Quantidade = produtoAtualizado.Quantidade,
                Valor = produtoAtualizado.Valor
            };
        }
    }
}