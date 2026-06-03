using Sistema_de_delivery_back.Domain.Entities;
using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Domain.Repositories;
using System;
using System.Threading.Tasks; 

namespace Sistema_de_delivery_back.Application.UseCases.Usuarios;

public class CreateUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public CreateUsuarioUseCase(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    public async Task<UsuarioDto> Execute(CreateUsuarioDto dto)
    {
        var usuarioExistente = await _usuarioRepository.BuscarPorEmail(dto.Email);

        if (usuarioExistente != null)
        {
            throw new Exception($"Já existe um usuário com o email {dto.Email}.");
        }

        var senhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha);

        var usuario = new Usuario(dto.Nome, dto.Email, dto.Telefone, dto.Tipo, senhaHash);

        await _usuarioRepository.Adicionar(usuario);

        return new UsuarioDto
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email,
            Telefone = usuario.Telefone,
            Tipo = usuario.Tipo
        };
    }
}