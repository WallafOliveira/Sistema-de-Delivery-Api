using Sistema_de_delivery_back.Domain.Entities;
using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Domain.Repositories;
using System;
using System.Threading.Tasks; // Importação necessária para o Task

namespace Sistema_de_delivery_back.Application.UseCases.Usuarios;

public class CreateUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public CreateUsuarioUseCase(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    // 1. Transformado em método assíncrono (async Task)
    public async Task<UsuarioDto> Execute(CreateUsuarioDto dto)
    {
        // 2. Adicionado o 'await' na busca por email
        var usuarioExistente = await _usuarioRepository.BuscarPorEmail(dto.Email);

        if (usuarioExistente != null)
        {
            throw new Exception($"Já existe um usuário com o email {dto.Email}.");
        }

        var senhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha);

        var usuario = new Usuario(dto.Nome, dto.Email, dto.Telefone, dto.Tipo, senhaHash);

        // 3. Adicionado o 'await' ao salvar no banco de dados
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