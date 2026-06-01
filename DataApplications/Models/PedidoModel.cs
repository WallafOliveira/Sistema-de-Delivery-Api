using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataApplications.Models;

public class PedidoModel
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid ClienteId { get; set; }

    [Required]
    public Guid RestauranteId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Status { get; set; } = null!;

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal ValorTotal { get; set; }

    [Required]
    public DateTime DataCriacao { get; set; }

    public DateTime? DataAtualizacao { get; set; }

    [Required]
    public bool Ativo { get; set; }

    public ICollection<ItemPedidoModel> Itens { get; set; } = new List<ItemPedidoModel>();
}
