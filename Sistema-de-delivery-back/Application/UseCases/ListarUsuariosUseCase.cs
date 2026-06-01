using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace Sistema_de_delivery_back.Application.UseCases.Usuarios;

public class ListarUsuariosUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public ListarUsuariosUseCase(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<List<UsuarioDto>> Execute()
    {
        var usuarios = await _usuarioRepository.ListarTodos();

        return usuarios.Select(u => new UsuarioDto
        {
            Id = u.Id,
            Nome = u.Nome,
            Email = u.Email,
            Telefone = u.Telefone,
            Tipo = u.Tipo
        }).ToList();
    }
}