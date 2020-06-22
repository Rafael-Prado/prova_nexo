using System;

namespace prova_nexo_domain.Domain
{
    public class Produto
    {
        public Produto(Guid id, string nome, decimal valor, bool disponivel)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
            Disponivel = disponivel;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
        public bool Disponivel { get; private set; }

        public Guid ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
        
    }
}
