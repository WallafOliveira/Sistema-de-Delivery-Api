using DataApplications.Models;
using Microsoft.EntityFrameworkCore;

namespace DataApplications.Data;

public class DeliveryDbContext : DbContext
{
    public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) : base(options) { }

    public DbSet<UsuarioModel> Usuarios { get; set; }
    public DbSet<RestauranteModel> Restaurantes { get; set; }
    public DbSet<ProdutoModel> Produtos { get; set; }
    public DbSet<PedidoModel> Pedidos { get; set; }
    public DbSet<ItemPedidoModel> ItensPedido { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UsuarioModel>().ToTable("Usuarios");
        modelBuilder.Entity<RestauranteModel>().ToTable("Restaurantes");
        modelBuilder.Entity<ProdutoModel>().ToTable("Produtos");
        modelBuilder.Entity<PedidoModel>().ToTable("Pedidos");
        modelBuilder.Entity<ItemPedidoModel>().ToTable("ItensPedido");

        base.OnModelCreating(modelBuilder);

    }
}
