using System.ComponentModel.DataAnnotations;

namespace DataApplications.Entities;

public class ItemPedido
{
    [Key]
    public Guid Id { get; private set; }
    public Guid PedidoId { get; private set; }
    public Guid ProdutoId { get; private set; }
    public string NomeProduto { get; private set; } = null!;
    public int Quantidade { get; private set; }
    public decimal ValorUnitario { get; private set; }
    public decimal ValorTotal { get; private set; }

    public ItemPedido(Guid pedidoId, Guid produtoId, string nomeProduto, int quantidade, decimal valorUnitario)
    {
        if (quantidade <= 0) throw new ArgumentException("A quantidade deve ser maior que zero.");
        if (valorUnitario <= 0) throw new ArgumentException("O valor unitario deve ser maior que zero.");

        Id = Guid.NewGuid();
        PedidoId = pedidoId;
        ProdutoId = produtoId;
        NomeProduto = nomeProduto;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
        ValorTotal = quantidade * valorUnitario;
    }

    private ItemPedido() { }
}
