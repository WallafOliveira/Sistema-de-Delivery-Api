using Microsoft.AspNetCore.Mvc;
using Sistema_de_delivery_cardapio.Application.DTOs.Restaurantes;
using Sistema_de_delivery_cardapio.Application.UseCases.Restaurantes;
using System;
using System.Threading.Tasks;

namespace Sistema_de_delivery_cardapio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestauranteController : ControllerBase
    {
        private readonly CreateRestauranteUseCase _createRestauranteUseCase;
        private readonly UpdateRestauranteUseCase _updateRestauranteUseCase;
        private readonly ListarRestaurantesUseCase _listarRestaurantesUseCase;
        private readonly ListarRestaurantesAbertosUseCase _listarRestaurantesAbertosUseCase;
        private readonly BuscarRestaurantePorIdUseCase _buscarRestaurantePorIdUseCase;

        public RestauranteController(
            CreateRestauranteUseCase createRestauranteUseCase,
            UpdateRestauranteUseCase updateRestauranteUseCase,
            ListarRestaurantesUseCase listarRestaurantesUseCase,
            ListarRestaurantesAbertosUseCase listarRestaurantesAbertosUseCase,
            BuscarRestaurantePorIdUseCase buscarRestaurantePorIdUseCase)
        {
            _createRestauranteUseCase = createRestauranteUseCase;
            _updateRestauranteUseCase = updateRestauranteUseCase;
            _listarRestaurantesUseCase = listarRestaurantesUseCase;
            _listarRestaurantesAbertosUseCase = listarRestaurantesAbertosUseCase;
            _buscarRestaurantePorIdUseCase = buscarRestaurantePorIdUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRestauranteDto dto)
        {
            try
            {
                var resultado = await _createRestauranteUseCase.Execute(dto);
                return CreatedAtAction(nameof(GetById), new { id = resultado.Id }, resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRestauranteDto dto)
        {
            try
            {
                var resultado = await _updateRestauranteUseCase.Execute(id, dto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var resultado = await _listarRestaurantesUseCase.Execute();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("abertos")]
        public async Task<IActionResult> GetAbertos()
        {
            try
            {
                var resultado = await _listarRestaurantesAbertosUseCase.Execute();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var resultado = await _buscarRestaurantePorIdUseCase.Execute(id);

                if (resultado == null)
                    return NotFound(new { message = $"Restaurante com ID {id} não encontrado." });

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
