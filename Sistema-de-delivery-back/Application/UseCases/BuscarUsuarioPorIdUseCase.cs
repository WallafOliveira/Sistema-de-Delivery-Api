using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Domain.Interfaces;

namespace Sistema_de_delivery_back.Application.UseCases;

public class BuscarUsuarioPorIdUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public BuscarUsuarioPorIdUseCase(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public UsuarioDto? Execute(Guid id)
    {
        var usuario = _usuarioRepository.BuscarPorId(id);

        if (usuario == null)
        {
            return null;
        }

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
