using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Domain.Repositories;

namespace Sistema_de_delivery_back.Application.UseCases;

public class LoginUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public LoginUsuarioUseCase(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<UsuarioDto?> ExecutarAsync(LoginDto loginDto)
    {
        var usuario = await _usuarioRepository.BuscarPorEmail(loginDto.Email);

        if (usuario is null || !BCrypt.Net.BCrypt.Verify(loginDto.Senha, usuario.SenhaHash))
            return null;

        return new UsuarioDto
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            Telefone = usuario.Telefone,
            Tipo = usuario.Tipo,
            RestauranteId = usuario.RestauranteId
        };
    }
}