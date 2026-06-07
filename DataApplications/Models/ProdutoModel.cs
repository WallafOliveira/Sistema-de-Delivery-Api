using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataApplications.Models
{
    public class ProdutoModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid RestauranteId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; } = null!;

        [MaxLength(1000)]
        public string? ImagemProduto { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}
