using System;

namespace prova_nexo_web.Models
{
    public class ProdutoModel
    {
        public Guid Id { get;  set; }
        public string Nome { get;  set; }
        public decimal Valor { get;  set; }
        public bool Disponivel { get;  set; }

        public Guid ClienteId { get; set; }

        public virtual ClienteModel Cliente { get; set; }
    }
}