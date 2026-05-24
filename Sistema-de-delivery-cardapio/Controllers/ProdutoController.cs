using Microsoft.AspNetCore.Mvc;
using Sistema_de_delivery_cardapio.Application.DTOs.Produtos;
using Sistema_de_delivery_cardapio.Application.UseCases.Produtos;

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
        public IActionResult Criar([FromBody] CreateProdutoDto dto)
        {
            try
            {
                var resultado = _createProdutoUseCase.Executar(dto);
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
        public IActionResult Atualizar(Guid id, [FromBody] UpdateProdutoDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return BadRequest(new { erro = "O ID da URL não confere com o ID do produto." });

                var resultado = _updateProdutoUseCase.Executar(dto);
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
        public IActionResult ObterTodos()
        {
            var produtos = _listarProdutosUseCase.Executar();
            return Ok(produtos);
        }

        [HttpGet("restaurante/{restauranteId}")]
        public IActionResult ObterPorRestaurante(Guid restauranteId)
        {
            var produtos = _listarProdutosPorRestauranteUseCase.Executar(restauranteId);

            if (!produtos.Any())
                return NotFound(new { mensagem = "Nenhum produto encontrado para este restaurante." });

            return Ok(produtos);
        }
    }
}
