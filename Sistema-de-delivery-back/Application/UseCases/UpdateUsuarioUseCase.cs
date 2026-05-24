using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Domain.Interfaces;

namespace Sistema_de_delivery_back.Application.UseCases;

public class UpdateUsuarioUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UpdateUsuarioUseCase(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public UsuarioDto Execute(Guid id, UpdateUsuarioDto dto)
    {
        var usuario = _usuarioRepository.BuscarPorId(id);

        if (usuario == null)
        {
            throw new Exception($"Usuário com ID {id} não encontrado.");
        }

        usuario.AtualizarDados(dto.Nome, dto.Email, dto.Telefone, dto.Tipo);

        _usuarioRepository.Atualizar(usuario);

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
