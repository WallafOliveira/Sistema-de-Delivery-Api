using Microsoft.AspNetCore.Mvc;
using Sistema_de_delivery_cardapio.Application.DTOs.Produtos;
using Sistema_de_delivery_cardapio.Application.UseCases.Produtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_delivery_cardapio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly CreateProdutoUseCase _createProdutoUseCase;
        private readonly UpdateProdutoUseCase _updateProdutoUseCase;
        private readonly ListarProdutoUseCase _listarProdutosUseCase;
        private readonly ListarProdutosPorRestauranteUseCase _listarProdutosPorRestauranteUseCase;

        public ProdutoController(
            CreateProdutoUseCase createProdutoUseCase,
            UpdateProdutoUseCase updateProdutoUseCase,
            ListarProdutoUseCase listarProdutosUseCase,
            ListarProdutosPorRestauranteUseCase listarProdutosPorRestauranteUseCase)
        {
            _createProdutoUseCase = createProdutoUseCase;
            _updateProdutoUseCase = updateProdutoUseCase;
            _listarProdutosUseCase = listarProdutosUseCase;
            _listarProdutosPorRestauranteUseCase = listarProdutosPorRestauranteUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CreateProdutoDto dto)
        {
            try
            {
                var resultado = await _createProdutoUseCase.Executar(dto);
                return Created("", resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = "Erro interno no servidor.", detalhe = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] UpdateProdutoDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return BadRequest(new { erro = "O ID da URL não confere com o ID do produto." });

                var resultado = await _updateProdutoUseCase.Executar(dto);
                return Ok(resultado);
            }
            catch (Exception ex) when (ex.Message == "Produto não encontrado.")
            {
                return NotFound(new { erro = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { erro = "Erro interno no servidor." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var produtos = await _listarProdutosUseCase.Executar();
            return Ok(produtos);
        }

        [HttpGet("restaurante/{restauranteId}")]
        public async Task<IActionResult> ObterPorRestaurante(Guid restauranteId)
        {
            var produtos = await _listarProdutosPorRestauranteUseCase.Executar(restauranteId);

            if (!produtos.Any())
                return NotFound(new { mensagem = "Nenhum produto encontrado para este restaurante." });

            return Ok(produtos);
        }
    }
}