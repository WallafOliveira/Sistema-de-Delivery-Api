using System.ComponentModel.DataAnnotations;

namespace DataApplications.Models
{
    public class ProdutoModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid RestauranteId { get; set; }
        public virtual RestauranteModel Restaurante { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }

    }
}
