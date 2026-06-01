using System;
using System.ComponentModel.DataAnnotations;

namespace DataApplications.Models
{
    public class UsuarioModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string SenhaHash { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }
    }
}