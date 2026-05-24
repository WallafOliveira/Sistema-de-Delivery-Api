using Microsoft.AspNetCore.Mvc;
using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Application.UseCases;
using Sistema_de_delivery_back.Application.UseCases.Usuarios;

namespace Sistema_de_delivery_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly CreateUsuarioUseCase _createUsuarioUseCase;
    private readonly UpdateUsuarioUseCase _updateUsuarioUseCase;
    private readonly ListarUsuariosUseCase _listarUsuariosUseCase;
    private readonly BuscarUsuarioPorIdUseCase _buscarUsuarioPorIdUseCase;

    public UsuarioController(
        CreateUsuarioUseCase createUsuarioUseCase,
        UpdateUsuarioUseCase updateUsuarioUseCase,
        ListarUsuariosUseCase listarUsuariosUseCase,
        BuscarUsuarioPorIdUseCase buscarUsuarioPorIdUseCase)
    {
        _createUsuarioUseCase = createUsuarioUseCase;
        _updateUsuarioUseCase = updateUsuarioUseCase;
        _listarUsuariosUseCase = listarUsuariosUseCase;
        _buscarUsuarioPorIdUseCase = buscarUsuarioPorIdUseCase;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateUsuarioDto dto)
    {
        try
        {
            var resultado = _createUsuarioUseCase.Execute(dto);
            return CreatedAtAction(nameof(GetById), new { id = resultado.Id }, resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] UpdateUsuarioDto dto)
    {
        try
        {
            var resultado = _updateUsuarioUseCase.Execute(id, dto);
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
            var resultado = _listarUsuariosUseCase.Execute();
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
            var resultado = _buscarUsuarioPorIdUseCase.Execute(id);
            
            if (resultado == null)
            {
                return NotFound(new { message = $"Usuário com ID {id} não encontrado." });
            }

            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
