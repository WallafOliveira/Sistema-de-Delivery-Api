using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataApplications.Data;
using DataApplications.Models;
using Sistema_de_delivery_cardapio.Domain.Entities;
using Sistema_de_delivery_cardapio.Domain.Interfaces;

namespace Sistema_de_delivery_cardapio.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DeliveryDbContext _context;

        public ProdutoRepository(DeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> Adicionar(Produto produto)
        {
            var model = new ProdutoModel
            {
                Id = produto.Id,
                RestauranteId = produto.RestauranteId,
                Nome = produto.Nome,
                ImagemProduto = produto.ImagemProduto,
                Quantidade = produto.Quantidade,
                Valor = produto.Valor,
                DataCriacao = produto.DataCriacao,
                DataAtualizacao = produto.DataAtualizacao,
                Ativo = produto.Ativo
            };

            await _context.Produtos.AddAsync(model);
            await _context.SaveChangesAsync();

            typeof(Produto).GetProperty("Id")?.SetValue(produto, model.Id);
            return produto;
        }

        public async Task<Produto?> Atualizar(Guid id, Produto produto)
        {
            var existing = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
            if (existing is null) return null;

            existing.Nome = produto.Nome;
            existing.ImagemProduto = produto.ImagemProduto;
            existing.Quantidade = produto.Quantidade;
            existing.Valor = produto.Valor;
            existing.DataAtualizacao = produto.DataAtualizacao;
            existing.Ativo = produto.Ativo;

            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto?> ObterPorId(Guid id)
        {
            var m = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
            if (m is null) return null;

            return MapToEntity(m);
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            var models = await _context.Produtos.ToListAsync();
            var list = new List<Produto>();

            foreach (var m in models)
            {
                list.Add(MapToEntity(m));
            }

            return list;
        }

        public async Task<IEnumerable<Produto>> ObterPorRestauranteId(Guid restauranteId)
        {
            var models = await _context.Produtos
                .Where(p => p.RestauranteId == restauranteId)
                .ToListAsync();

            var list = new List<Produto>();

            foreach (var m in models)
            {
                list.Add(MapToEntity(m));
            }

            return list;
        }

        private Produto MapToEntity(ProdutoModel m)
        {
            var produto = (Produto)Activator.CreateInstance(typeof(Produto), true)!;

            typeof(Produto).GetProperty("Id")?.SetValue(produto, m.Id);
            typeof(Produto).GetProperty("RestauranteId")?.SetValue(produto, m.RestauranteId);
            typeof(Produto).GetProperty("Nome")?.SetValue(produto, m.Nome);
            typeof(Produto).GetProperty("ImagemProduto")?.SetValue(produto, m.ImagemProduto);
            typeof(Produto).GetProperty("Quantidade")?.SetValue(produto, m.Quantidade);
            typeof(Produto).GetProperty("Valor")?.SetValue(produto, m.Valor);
            typeof(Produto).GetProperty("DataCriacao")?.SetValue(produto, m.DataCriacao);
            typeof(Produto).GetProperty("DataAtualizacao")?.SetValue(produto, m.DataAtualizacao);
            typeof(Produto).GetProperty("Ativo")?.SetValue(produto, m.Ativo);

            return produto;
        }
    }
}