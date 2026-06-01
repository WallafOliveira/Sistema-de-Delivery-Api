using System.ComponentModel.DataAnnotations;

namespace DataApplications.Models;

public class ItemPedidoModel
{
    [Key]
    public Guid Id { get; set; }
    public Guid PedidoId { get; set; }
    public Guid ProdutoId { get; set; }
    public string NomeProduto { get; set; } = null!;
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
    public decimal ValorTotal { get; set; }

}
