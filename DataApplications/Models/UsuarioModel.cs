using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataApplications.Models
{
    public class UsuarioModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string Telefone { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Tipo { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string SenhaHash { get; set; } = null!;

        public Guid? RestauranteId { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}