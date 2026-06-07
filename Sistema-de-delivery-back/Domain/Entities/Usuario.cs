using System;

namespace Sistema_de_delivery_back.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string Telefone { get; private set; } = null!;
        public string Tipo { get; private set; } = null!;
        public string SenhaHash { get; private set; } = null!;
        public Guid? RestauranteId { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }
        public bool Ativo { get; private set; }

        // Construtor privado exigido para o Activator.CreateInstance no repositório
        private Usuario() { }

        public Usuario(string nome, string email, string telefone, string tipo, string senhaHash, Guid? restauranteId = null)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("E-mail é obrigatório.");

            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Tipo = tipo;
            SenhaHash = senhaHash;
            RestauranteId = restauranteId;
            DataCriacao = DateTime.UtcNow;
            Ativo = true;
        }

        public void AtualizarDados(string nome, string email, string telefone, string tipo, Guid? restauranteId = null)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Tipo = tipo;
            RestauranteId = restauranteId;
            DataAtualizacao = DateTime.UtcNow;
        }

        public void Desativar()
        {
            Ativo = false;
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}