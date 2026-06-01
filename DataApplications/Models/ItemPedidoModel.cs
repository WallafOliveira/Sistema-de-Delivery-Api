using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataApplications.Models;

public class ItemPedidoModel
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid PedidoId { get; set; }

    [Required]
    public Guid ProdutoId { get; set; }

    [Required]
    [MaxLength(200)]
    public string NomeProduto { get; set; } = null!;

    [Required]
    public int Quantidade { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal ValorUnitario { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal ValorTotal { get; set; }
}
