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
        public IActionResult Criar([FromBody] CreatePedidoDto dto)
        {
            try
            {
                var resultado = _createPedidoUseCase.Executar(dto);
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
        public IActionResult AtualizarStatus(Guid id, [FromBody] UpdatePedidoStatusDto dto)
        {
            try
            {
                if (id != dto.Id)
                    return BadRequest(new { erro = "O ID da URL não confere com o ID do pedido." });

                var resultado = _atualizarStatusPedidoUseCase.Executar(dto);
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
        public IActionResult Cancelar(Guid id)
        {
            try
            {
                _cancelarPedidoUseCase.Executar(id);
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
        public IActionResult ObterTodos()
        {
            var pedidos = _listarPedidosUseCase.Executar();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(Guid id)
        {
            try
            {
                var pedido = _buscarPedidoPorIdUseCase.Executar(id);
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
        public IActionResult ObterPorCliente(Guid clienteId)
        {
            var pedidos = _listarPedidosPorClienteUseCase.Executar(clienteId);
            return Ok(pedidos);
        }
    }
}
