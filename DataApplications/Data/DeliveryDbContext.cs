using DataApplications.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataApplications.Data;

public class DeliveryDbContext : DbContext
{
    public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Restaurante> Restaurantes { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Telefone).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Tipo).IsRequired().HasMaxLength(50);
            entity.Property(e => e.SenhaHash).IsRequired();
            entity.Property(e => e.DataCriacao).IsRequired();
            entity.Property(e => e.DataAtualizacao);
            entity.Property(e => e.Ativo).IsRequired();
            entity.HasIndex(e => e.Email).IsUnique();
        });

        modelBuilder.Entity<Restaurante>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(200);
            entity.Property(e => e.CPNJ).IsRequired().HasMaxLength(18);
            entity.Property(e => e.Endereco).IsRequired().HasMaxLength(500);
            entity.Property(e => e.EstaAberto).IsRequired();
            entity.Property(e => e.DataCriacao).IsRequired();
            entity.Property(e => e.DataAtualizacao);
            entity.Property(e => e.Ativo).IsRequired();
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Valor).IsRequired().HasPrecision(18, 2);
            entity.Property(e => e.DataCriacao).IsRequired();
            entity.Property(e => e.DataAtualizacao);
            entity.Property(e => e.Ativo).IsRequired();

            entity.HasOne(e => e.Restaurante)
                  .WithMany()
                  .HasForeignKey(e => e.RestauranteId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
