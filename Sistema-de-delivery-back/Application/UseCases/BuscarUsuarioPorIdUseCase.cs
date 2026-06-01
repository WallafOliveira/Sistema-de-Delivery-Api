using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Domain.Repositories;
using System.Threading.Tasks; 

namespace Sistema_de_delivery_back.Application.UseCases;

public class BuscarUsuarioPorIdUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public BuscarUsuarioPorIdUseCase(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    public async Task<UsuarioDto?> Execute(Guid id)
    {
        var usuario = await _usuarioRepository.BuscarPorId(id);

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