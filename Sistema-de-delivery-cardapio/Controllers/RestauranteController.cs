using Microsoft.AspNetCore.Mvc;
using Sistema_de_delivery_cardapio.Application.DTOs.Restaurantes;
using Sistema_de_delivery_cardapio.Application.UseCases.Restaurantes;

namespace Sistema_de_delivery_cardapio.Controllers;

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
    public IActionResult Create([FromBody] CreateRestauranteDto dto)
    {
        try
        {
            var resultado = _createRestauranteUseCase.Execute(dto);
            return CreatedAtAction(nameof(GetById), new { id = resultado.Id }, resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] UpdateRestauranteDto dto)
    {
        try
        {
            var resultado = _updateRestauranteUseCase.Execute(id, dto);
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var resultado = _listarRestaurantesUseCase.Execute();
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("abertos")]
    public IActionResult GetAbertos()
    {
        try
        {
            var resultado = _listarRestaurantesAbertosUseCase.Execute();
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        try
        {
            var resultado = _buscarRestaurantePorIdUseCase.Execute(id);

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
