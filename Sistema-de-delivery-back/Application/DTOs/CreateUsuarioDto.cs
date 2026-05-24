namespace Sistema_de_delivery_back.Application.DTOs;

public class CreateUsuarioDto
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
