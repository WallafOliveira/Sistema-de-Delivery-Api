using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_delivery_pedido.Application.DTOs.Pedidos;
using Sistema_de_delivery_pedido.Application.UseCases.Pedidos;

namespace Sistema_de_delivery_pedido.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly CreatePedidoUseCase _createPedidoUseCase;
        private readonly AtualizarStatusPedidoUseCase _atualizarStatusPedidoUseCase;
        private readonly ListarPedidosUseCase _listarPedidosUseCase;
        private readonly ListarPedidosPorClienteUseCase _listarPedidosPorClienteUseCase;
        private readonly BuscarPedidoPorIdUseCase _buscarPedidoPorIdUseCase;
        private readonly CancelarPedidoUseCase _cancelarPedidoUseCase;

        public PedidoController(
            CreatePedidoUseCase createPedidoUseCase,
            AtualizarStatusPedidoUseCase atualizarStatusPedidoUseCase,
            ListarPedidosUseCase listarPedidosUseCase,
            ListarPedidosPorClienteUseCase listarPedidosPorClienteUseCase,
            BuscarPedidoPorIdUseCase buscarPedidoPorIdUseCase,
            CancelarPedidoUseCase cancelarPedidoUseCase)
        {
            _createPedidoUseCase = createPedidoUseCase;
            _atualizarStatusPedidoUseCase = atualizarStatusPedidoUseCase;
            _listarPedidosUseCase = listarPedidosUseCase;
            _listarPedidosPorClienteUseCase = listarPedidosPorClienteUseCase;
            _buscarPedidoPorIdUseCase = buscarPedidoPorIdUseCase;
            _cancelarPedidoUseCase = cancelarPedidoUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CreatePedidoDto dto)
        {
            try
            {
                var resultado = await _createPedidoUseCase.Executar(dto);
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

        [HttpPut("{id}/status")]
        public async Task<IActionResult> AtualizarStatus(Guid id, [FromBody] UpdatePedidoStatusDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return BadRequest(new { erro = "O ID da URL não confere com o ID do pedido." });

                var resultado = await _atualizarStatusPedidoUseCase.Executar(dto);
                return Ok(resultado);
            }
            catch (Exception ex) when (ex.Message == "Pedido não encontrado.")
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

        [HttpDelete("{id}/cancelar")]
        public async Task<IActionResult> Cancelar(Guid id)
        {
            try
            {
                await _cancelarPedidoUseCase.Executar(id);
                return NoContent();
            }
            catch (Exception ex) when (ex.Message == "Pedido não encontrado.")
            {
                return NotFound(new { erro = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { erro = "Erro interno no servidor." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var pedidos = await _listarPedidosUseCase.Executar();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            try
            {
                var pedido = await _buscarPedidoPorIdUseCase.Executar(id);
                return Ok(pedido);
            }
            catch (Exception ex) when (ex.Message == "Pedido não encontrado.")
            {
                return NotFound(new { erro = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { erro = "Erro interno no servidor." });
            }
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<IActionResult> ObterPorCliente(Guid clienteId)
        {
            var pedidos = await _listarPedidosPorClienteUseCase.Executar(clienteId);
            return Ok(pedidos);
        }
    }
}
