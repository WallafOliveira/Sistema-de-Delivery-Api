using System.ComponentModel.DataAnnotations;

namespace DataApplications.Entities
{
    public class Produto
    {
        [Key]
        public Guid Id { get; private set; }
        public Guid RestauranteId { get; private set; }
        public virtual Restaurante Restaurante { get; private set; } = null!;
        public string Nome { get; private set; } = null!;
        public int Quantidade { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }
        public bool Ativo { get; private set; }

        public Produto(Guid restauranteId, string nome, int quantidade, decimal valor)
        {
            if (valor <= 0) throw new ArgumentException("O valor deve ser maior que zero.");
            if (quantidade < 0) throw new ArgumentException("A quantidade não pode ser negativa.");

            Id = Guid.NewGuid();
            RestauranteId = restauranteId;
            Nome = nome;
            Quantidade = quantidade;
            Valor = valor;
            DataCriacao = DateTime.UtcNow;
            Ativo = true;
        }

        private Produto() { }

        public void DeduzirQuantidade(int quantidadeComprada)
        {
            if (Quantidade < quantidadeComprada)
                throw new InvalidOperationException("Estoque insuficiente.");
            Quantidade -= quantidadeComprada;
            DataAtualizacao = DateTime.UtcNow;
        }

        public void AtualizarDetalhes(string nome, int quantidade, decimal valor)
        {
            if (valor <= 0) throw new ArgumentException("O valor deve ser maior que zero.");
            if (quantidade < 0) throw new ArgumentException("A quantidade não pode ser negativa.");
            Nome = nome;
            Quantidade = quantidade;
            Valor = valor;
            DataAtualizacao = DateTime.UtcNow;
        }

        public void Desativar()
        {
            Ativo = false;
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}
