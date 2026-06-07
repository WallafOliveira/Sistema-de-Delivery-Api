using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Domain.Repositories;
using System;
using System.Threading.Tasks; // Lembre-se de importar

namespace Sistema_de_delivery_back.Application.UseCases;

public class UpdateUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UpdateUsuarioUseCase(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    public async Task<UsuarioDto> Execute(Guid id, UpdateUsuarioDto dto)
    {
        var usuario = await _usuarioRepository.BuscarPorId(id);

        if (usuario == null)
        {
            throw new Exception($"Usuário com ID {id} não encontrado.");
        }

        usuario.AtualizarDados(dto.Nome, dto.Email, dto.Telefone, dto.Tipo, dto.RestauranteId);

        await _usuarioRepository.Atualizar(id, usuario);

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