using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataApplications.Data;
using DataApplications.Models;
using Sistema_de_delivery_pedido.Domain.Entities;
using Sistema_de_delivery_pedido.Domain.Interfaces;

namespace Sistema_de_delivery_pedido.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DeliveryDbContext _context;

        public PedidoRepository(DeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<Pedido> Adicionar(Pedido pedido)
        {
            var model = new PedidoModel
            {
                Id = pedido.Id,
                ClienteId = pedido.ClienteId,
                RestauranteId = pedido.RestauranteId,
                Status = pedido.Status,
                ValorTotal = pedido.ValorTotal,
                DataCriacao = pedido.DataCriacao,
                DataAtualizacao = pedido.DataAtualizacao,
                Ativo = pedido.Ativo,
                Itens = pedido.Itens.Select(item => new ItemPedidoModel
                {
                    Id = item.Id,
                    PedidoId = item.PedidoId,
                    ProdutoId = item.ProdutoId,
                    NomeProduto = item.NomeProduto,
                    Quantidade = item.Quantidade,
                    ValorUnitario = item.ValorUnitario,
                    ValorTotal = item.ValorTotal
                }).ToList()
            };

            await _context.Pedidos.AddAsync(model);
            await _context.SaveChangesAsync();

            typeof(Pedido).GetProperty("Id")?.SetValue(pedido, model.Id);
            return pedido;
        }

        public async Task<Pedido?> Atualizar(Guid id, Pedido pedido)
        {
            var existing = await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == id);
            if (existing is null) return null;

            existing.Status = pedido.Status;
            existing.ValorTotal = pedido.ValorTotal;
            existing.DataAtualizacao = pedido.DataAtualizacao;
            existing.Ativo = pedido.Ativo;

            await _context.SaveChangesAsync();

            return pedido;
        }

        public async Task<Pedido?> ObterPorId(Guid id)
        {
            var m = await _context.Pedidos
                .Include(p => p.Itens)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (m is null) return null;

            return MapToEntity(m);
        }

        public async Task<IEnumerable<Pedido>> ObterTodos()
        {
            var models = await _context.Pedidos
                .Include(p => p.Itens)
                .ToListAsync();

            var list = new List<Pedido>();

            foreach (var m in models)
            {
                list.Add(MapToEntity(m));
            }

            return list;
        }

        public async Task<IEnumerable<Pedido>> ObterPorClienteId(Guid clienteId)
        {
            var models = await _context.Pedidos
                .Include(p => p.Itens)
                .Where(p => p.ClienteId == clienteId)
                .ToListAsync();

            var list = new List<Pedido>();

            foreach (var m in models)
            {
                list.Add(MapToEntity(m));
            }

            return list;
        }

        public async Task<IEnumerable<Pedido>> ObterPorRestauranteId(Guid restauranteId)
        {
            var models = await _context.Pedidos
                .Include(p => p.Itens)
                .Where(p => p.RestauranteId == restauranteId)
                .ToListAsync();

            var list = new List<Pedido>();

            foreach (var m in models)
            {
                list.Add(MapToEntity(m));
            }

            return list;
        }

        private Pedido MapToEntity(PedidoModel m)
        {
            var pedido = (Pedido)Activator.CreateInstance(typeof(Pedido), true)!;

            typeof(Pedido).GetProperty("Id")?.SetValue(pedido, m.Id);
            typeof(Pedido).GetProperty("ClienteId")?.SetValue(pedido, m.ClienteId);
            typeof(Pedido).GetProperty("RestauranteId")?.SetValue(pedido, m.RestauranteId);
            typeof(Pedido).GetProperty("Status")?.SetValue(pedido, m.Status);
            typeof(Pedido).GetProperty("ValorTotal")?.SetValue(pedido, m.ValorTotal);
            typeof(Pedido).GetProperty("DataCriacao")?.SetValue(pedido, m.DataCriacao);
            typeof(Pedido).GetProperty("DataAtualizacao")?.SetValue(pedido, m.DataAtualizacao);
            typeof(Pedido).GetProperty("Ativo")?.SetValue(pedido, m.Ativo);

            var itens = new List<ItemPedido>();
            foreach (var itemModel in m.Itens)
            {
                var item = (ItemPedido)Activator.CreateInstance(typeof(ItemPedido), true)!;

                typeof(ItemPedido).GetProperty("Id")?.SetValue(item, itemModel.Id);
                typeof(ItemPedido).GetProperty("PedidoId")?.SetValue(item, itemModel.PedidoId);
                typeof(ItemPedido).GetProperty("ProdutoId")?.SetValue(item, itemModel.ProdutoId);
                typeof(ItemPedido).GetProperty("NomeProduto")?.SetValue(item, itemModel.NomeProduto);
                typeof(ItemPedido).GetProperty("Quantidade")?.SetValue(item, itemModel.Quantidade);
                typeof(ItemPedido).GetProperty("ValorUnitario")?.SetValue(item, itemModel.ValorUnitario);
                typeof(ItemPedido).GetProperty("ValorTotal")?.SetValue(item, itemModel.ValorTotal);

                itens.Add(item);
            }

            typeof(Pedido).GetProperty("Itens")?.SetValue(pedido, itens);

            return pedido;
        }
    }
}
