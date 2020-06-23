using System;
using System.Collections.Generic;

namespace prova_nexo_domain.Domain
{
    public class Cliente
    {
        public Cliente()
        {
            DataCadastro = DateTime.Now;
            ProdutoList = new List<Produto>();
            Ativo = true;
        }

        public Guid Id { get;  set; }
        public string Nome { get;  set; }
        public string SobreNome { get;  set; }
        public string Email { get;  set; }
        public DateTime DataCadastro { get;  set; }
        public bool Ativo { get;  set; }


        public virtual ICollection<Produto> ProdutoList { get; set; }
    }
}
