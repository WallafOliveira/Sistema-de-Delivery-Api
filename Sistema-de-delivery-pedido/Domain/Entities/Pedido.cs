using System;

namespace Sistema_de_delivery_pedido.Domain.Entities;

using System.Collections.Generic;
public class Pedido
{
    public Guid Id { get; private set; }
    public Guid ClienteId { get; private set; }
    public Guid RestauranteId { get; private set; }
    public string Status { get; private set; } = null!;
    public decimal ValorTotal { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime? DataAtualizacao { get; private set; }
    public bool Ativo { get; private set; }

    public List<ItemPedido> Itens { get; private set; } = new();

    public Pedido(Guid clienteId, Guid restauranteId)
    {
        Id = Guid.NewGuid();
        ClienteId = clienteId;
        RestauranteId = restauranteId;
        Status = "Pendente";
        ValorTotal = 0;
        DataCriacao = DateTime.UtcNow;
        Ativo = true;
    }

    private Pedido() { }

    public void AdicionarItem(ItemPedido item)
    {
        Itens.Add(item);
        ValorTotal += item.ValorTotal;
    }

    public void AtualizarStatus(string novoStatus)
    {
        Status = novoStatus;
        DataAtualizacao = DateTime.UtcNow;
    }

    public void Cancelar()
    {
        Status = "Cancelado";
        Ativo = false;
        DataAtualizacao = DateTime.UtcNow;
    }
}
