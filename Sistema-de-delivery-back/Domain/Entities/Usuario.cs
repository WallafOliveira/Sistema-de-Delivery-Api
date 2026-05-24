using System.ComponentModel.DataAnnotations;

namespace Sistema_de_delivery_back.Domain.Entities;

public class Usuario
{
    [Key]
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Telefone { get; private set; } = null!;
    public string Tipo { get; private set; } = null!;
    public string SenhaHash { get; private set; } = null!;
    public DateTime DataCriacao { get; private set; }
    public DateTime? DataAtualizacao { get; private set; }
    public bool Ativo { get; private set; }

    public Usuario(string nome, string email, string telefone, string tipo, string senhaHash)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Tipo = tipo;
        SenhaHash = senhaHash;
        DataCriacao = DateTime.UtcNow;
        Ativo = true;
    }

    private Usuario() { }

    public void AtualizarDados(string nome, string email, string telefone, string tipo)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Tipo = tipo;
        DataAtualizacao = DateTime.UtcNow;
    }

    public void AtualizarSenha(string novaSenhaHash)
    {
        SenhaHash = novaSenhaHash;
        DataAtualizacao = DateTime.UtcNow;
    }

    public void Desativar()
    {
        Ativo = false;
        DataAtualizacao = DateTime.UtcNow;
    }
}
