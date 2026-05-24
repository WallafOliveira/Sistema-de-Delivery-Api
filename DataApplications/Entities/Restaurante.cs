using System.ComponentModel.DataAnnotations;

namespace DataApplications.Entities
{
    public class Restaurante
    {
        [Key]
        public Guid Id { get; private set; }
        public string Nome { get; private set; } = null!;
        public string CPNJ { get; private set; } = null!;
        public string Endereco { get; private set; } = null!;
        public bool EstaAberto { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }
        public bool Ativo { get; private set; }

        public Restaurante(string nome, string cpnj, string endereco)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CPNJ = cpnj;
            Endereco = endereco;
            EstaAberto = false;
            DataCriacao = DateTime.UtcNow;
            Ativo = true;
        }

        private Restaurante() { }

        public void AtualizarDados(string nome, string cpnj, string endereco, bool estaAberto)
        {
            Nome = nome;
            CPNJ = cpnj;
            Endereco = endereco;
            EstaAberto = estaAberto;
            DataAtualizacao = DateTime.UtcNow;
        }

        public void Desativar()
        {
            Ativo = false;
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}
