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
        // Configuração de tabelas
        modelBuilder.Entity<UsuarioModel>().ToTable("Usuarios");
        modelBuilder.Entity<RestauranteModel>().ToTable("Restaurantes");
        modelBuilder.Entity<ProdutoModel>().ToTable("Produtos");
        modelBuilder.Entity<PedidoModel>().ToTable("Pedidos");
        modelBuilder.Entity<ItemPedidoModel>().ToTable("ItensPedido");

        // Configuração de relacionamento Pedido -> ItensPedido
        modelBuilder.Entity<PedidoModel>()
            .HasMany(p => p.Itens)
            .WithOne()
            .HasForeignKey(i => i.PedidoId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configuração de índices para Pedidos (melhorar performance)
        modelBuilder.Entity<PedidoModel>()
            .HasIndex(p => p.ClienteId)
            .HasDatabaseName("IX_Pedidos_ClienteId");

        modelBuilder.Entity<PedidoModel>()
            .HasIndex(p => p.RestauranteId)
            .HasDatabaseName("IX_Pedidos_RestauranteId");

        modelBuilder.Entity<PedidoModel>()
            .HasIndex(p => p.DataCriacao)
            .HasDatabaseName("IX_Pedidos_DataCriacao");

        modelBuilder.Entity<PedidoModel>()
            .HasIndex(p => p.Status)
            .HasDatabaseName("IX_Pedidos_Status");

        // Configuração de índices para Produtos
        modelBuilder.Entity<ProdutoModel>()
            .HasIndex(p => p.RestauranteId)
            .HasDatabaseName("IX_Produtos_RestauranteId");

        // Configuração de índices para Usuários
        modelBuilder.Entity<UsuarioModel>()
            .HasIndex(u => u.Email)
            .IsUnique()
            .HasDatabaseName("IX_Usuarios_Email");

        // Configuração de precisão decimal
        modelBuilder.Entity<PedidoModel>()
            .Property(p => p.ValorTotal)
            .HasPrecision(10, 2);

        modelBuilder.Entity<ItemPedidoModel>()
            .Property(i => i.ValorUnitario)
            .HasPrecision(10, 2);

        modelBuilder.Entity<ItemPedidoModel>()
            .Property(i => i.ValorTotal)
            .HasPrecision(10, 2);

        modelBuilder.Entity<ProdutoModel>()
            .Property(p => p.Valor)
            .HasPrecision(10, 2);

        base.OnModelCreating(modelBuilder);
    }
}
