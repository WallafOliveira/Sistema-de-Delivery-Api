using Microsoft.AspNetCore.Mvc;
using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Application.UseCases;
using Sistema_de_delivery_back.Application.UseCases.Usuarios;
using System;
using System.Threading.Tasks; // Necessário para o Task

namespace Sistema_de_delivery_back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly CreateUsuarioUseCase _createUsuarioUseCase;
    private readonly UpdateUsuarioUseCase _updateUsuarioUseCase;
    private readonly ListarUsuariosUseCase _listarUsuariosUseCase;
    private readonly BuscarUsuarioPorIdUseCase _buscarUsuarioPorIdUseCase;
    private readonly LoginUsuarioUseCase _loginUseCase;

    public UsuarioController(
        CreateUsuarioUseCase createUsuarioUseCase,
        UpdateUsuarioUseCase updateUsuarioUseCase,
        ListarUsuariosUseCase listarUsuariosUseCase,
        BuscarUsuarioPorIdUseCase buscarUsuarioPorIdUseCase,
        LoginUsuarioUseCase loginUsuarioUseCase)
    {
        _createUsuarioUseCase = createUsuarioUseCase;
        _updateUsuarioUseCase = updateUsuarioUseCase;
        _listarUsuariosUseCase = listarUsuariosUseCase;
        _buscarUsuarioPorIdUseCase = buscarUsuarioPorIdUseCase;
        _loginUseCase = loginUsuarioUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUsuarioDto dto)
    {
        try
        {
            var resultado = await _createUsuarioUseCase.Execute(dto);
            return CreatedAtAction(nameof(GetById), new { id = resultado.Id }, resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUsuarioDto dto)
    {
        try
        {
            var resultado = await _updateUsuarioUseCase.Execute(id, dto);
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
            var resultado = await _listarUsuariosUseCase.Execute();
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
            var resultado = await _buscarUsuarioPorIdUseCase.Execute(id);

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

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var usuario = await _loginUseCase.ExecutarAsync(loginDto);

        if (usuario is null)
            return Unauthorized();

        return Ok(usuario);
    }
}