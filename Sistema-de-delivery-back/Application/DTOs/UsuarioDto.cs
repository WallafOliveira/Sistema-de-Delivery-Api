namespace Sistema_de_delivery_back.Application.DTOs;

public class UsuarioDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
}
