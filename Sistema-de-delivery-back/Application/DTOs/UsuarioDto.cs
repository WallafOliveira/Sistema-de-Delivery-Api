namespace Sistema_de_delivery_back.Application.DTOs;

public class UsuarioDto
{
    // Dados que vão para a tabela de usuario
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Telefone { get; set; } = null!;
    public string Tipo { get; set; } = null!;

    public string Senha { get; set; } = null!;
}
