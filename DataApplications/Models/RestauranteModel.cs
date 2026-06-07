using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataApplications.Models
{
    public class RestauranteModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string CPNJ { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string Endereco { get; set; } = null!;

        [MaxLength(1000)]
        public string? Logo { get; set; }

        [Required]
        public bool EstaAberto { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}
