using System.ComponentModel.DataAnnotations;

namespace DataApplications.Models
{
    public class RestauranteModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string CPNJ { get; set; } = null!;
        public string Endereco { get; set; } = null!;
        public bool EstaAberto { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }
    }
}
