using System.ComponentModel.DataAnnotations;

namespace DataApplications.Models;

using System.Collections.Generic;
public class PedidoModel
{
    [Key]
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public Guid RestauranteId { get; set; }
    public string Status { get; set; } = null!;
    public decimal ValorTotal { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public bool Ativo { get; set; }

    public ICollection<ItemPedidoModel> Itens { get; set; } = new List<ItemPedidoModel>();
}
