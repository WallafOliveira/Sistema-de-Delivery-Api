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
    public class RestauranteRepository : IRestauranteRepository
    {
        private readonly DeliveryDbContext _context;

        public RestauranteRepository(DeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<Restaurante> Adicionar(Restaurante restaurante)
        {
            var model = new RestauranteModel
            {
                Id = restaurante.Id,
                Nome = restaurante.Nome,
                CPNJ = restaurante.CPNJ,
                Endereco = restaurante.Endereco,
                Logo = restaurante.Logo,
                EstaAberto = restaurante.EstaAberto,
                DataCriacao = restaurante.DataCriacao,
                DataAtualizacao = restaurante.DataAtualizacao,
                Ativo = restaurante.Ativo
            };

            await _context.Restaurantes.AddAsync(model);
            await _context.SaveChangesAsync();

            typeof(Restaurante).GetProperty("Id")?.SetValue(restaurante, model.Id);
            return restaurante;
        }

        public async Task<Restaurante?> Atualizar(Guid id, Restaurante restaurante)
        {
            var existing = await _context.Restaurantes.FirstOrDefaultAsync(r => r.Id == id);
            if (existing is null) return null;

            existing.Nome = restaurante.Nome;
            existing.CPNJ = restaurante.CPNJ;
            existing.Endereco = restaurante.Endereco;
            existing.Logo = restaurante.Logo;
            existing.EstaAberto = restaurante.EstaAberto;
            existing.DataAtualizacao = restaurante.DataAtualizacao;
            existing.Ativo = restaurante.Ativo;

            await _context.SaveChangesAsync();

            return restaurante;
        }

        public async Task<IEnumerable<Restaurante>> ListarTodos()
        {
            var models = await _context.Restaurantes.ToListAsync();
            var list = new List<Restaurante>();

            foreach (var m in models)
            {
                list.Add(MapToEntity(m));
            }

            return list;
        }

        public async Task<IEnumerable<Restaurante>> ListarAbertos()
        {
            var models = await _context.Restaurantes
                .Where(r => r.EstaAberto)
                .ToListAsync();

            var list = new List<Restaurante>();

            foreach (var m in models)
            {
                list.Add(MapToEntity(m));
            }

            return list;
        }

        public async Task<Restaurante?> BuscarPorId(Guid id)
        {
            var m = await _context.Restaurantes.FirstOrDefaultAsync(r => r.Id == id);
            if (m is null) return null;

            return MapToEntity(m);
        }

        private Restaurante MapToEntity(RestauranteModel m)
        {
            var restaurante = (Restaurante)Activator.CreateInstance(typeof(Restaurante), true)!;

            typeof(Restaurante).GetProperty("Id")?.SetValue(restaurante, m.Id);
            typeof(Restaurante).GetProperty("Nome")?.SetValue(restaurante, m.Nome);
            typeof(Restaurante).GetProperty("CPNJ")?.SetValue(restaurante, m.CPNJ);
            typeof(Restaurante).GetProperty("Endereco")?.SetValue(restaurante, m.Endereco);
            typeof(Restaurante).GetProperty("Logo")?.SetValue(restaurante, m.Logo);
            typeof(Restaurante).GetProperty("EstaAberto")?.SetValue(restaurante, m.EstaAberto);
            typeof(Restaurante).GetProperty("DataCriacao")?.SetValue(restaurante, m.DataCriacao);
            typeof(Restaurante).GetProperty("DataAtualizacao")?.SetValue(restaurante, m.DataAtualizacao);
            typeof(Restaurante).GetProperty("Ativo")?.SetValue(restaurante, m.Ativo);

            return restaurante;
        }
    }
}
