using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataApplications.Data;
using DataApplications.Models;
using Sistema_de_delivery_back.Domain.Entities;
using Sistema_de_delivery_back.Domain.Repositories;

namespace Sistema_de_delivery_back.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DeliveryDbContext _context;

        public UsuarioRepository(DeliveryDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            var model = new UsuarioModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                Tipo = usuario.Tipo,
                SenhaHash = usuario.SenhaHash,
                RestauranteId = usuario.RestauranteId,
                DataCriacao = usuario.DataCriacao,
                Ativo = usuario.Ativo
            };

            await _context.Usuarios.AddAsync(model);
            await _context.SaveChangesAsync();

            typeof(Usuario).GetProperty("Id")?.SetValue(usuario, model.Id);
            return usuario;
        }

        public async Task<Usuario?> BuscarPorId(Guid id)
        {
            var m = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (m is null) return null;

            return MapToEntity(m);
        }

        public async Task<Usuario?> BuscarPorEmail(string email)
        {
            var m = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
            if (m is null) return null;

            return MapToEntity(m);
        }

        public async Task<IEnumerable<Usuario>> ListarTodos()
        {
            var models = await _context.Usuarios.ToListAsync();
            var list = new List<Usuario>();

            foreach (var m in models)
            {
                list.Add(MapToEntity(m));
            }

            return list;
        }

        public async Task<Usuario?> Atualizar(Guid id, Usuario usuario)
        {
            var existing = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (existing is null) return null;

            existing.Nome = usuario.Nome;
            existing.Email = usuario.Email;
            existing.Telefone = usuario.Telefone;
            existing.Tipo = usuario.Tipo;
            existing.RestauranteId = usuario.RestauranteId;
            existing.Ativo = usuario.Ativo;
            existing.DataAtualizacao = usuario.DataAtualizacao;

            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var model = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (model is null) return false;

            _context.Usuarios.Remove(model);

            await _context.SaveChangesAsync();
            return true;
        }

        private Usuario MapToEntity(UsuarioModel m)
        {
            var usuario = (Usuario)Activator.CreateInstance(typeof(Usuario), true)!;

            typeof(Usuario).GetProperty("Id")?.SetValue(usuario, m.Id);
            typeof(Usuario).GetProperty("Nome")?.SetValue(usuario, m.Nome);
            typeof(Usuario).GetProperty("Email")?.SetValue(usuario, m.Email);
            typeof(Usuario).GetProperty("Telefone")?.SetValue(usuario, m.Telefone);
            typeof(Usuario).GetProperty("Tipo")?.SetValue(usuario, m.Tipo);
            typeof(Usuario).GetProperty("SenhaHash")?.SetValue(usuario, m.SenhaHash);
            typeof(Usuario).GetProperty("RestauranteId")?.SetValue(usuario, m.RestauranteId);
            typeof(Usuario).GetProperty("DataCriacao")?.SetValue(usuario, m.DataCriacao);
            typeof(Usuario).GetProperty("DataAtualizacao")?.SetValue(usuario, m.DataAtualizacao);
            typeof(Usuario).GetProperty("Ativo")?.SetValue(usuario, m.Ativo);

            return usuario;
        }
    }
}