﻿using System;

namespace prova_nexo_domain.Domain
{
    public class Produto
    {
        public Guid Id { get;  set; }
        public string Nome { get;  set; }
        public decimal Valor { get;  set; }
        public bool Disponivel { get;  set; }

        public Guid ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
        
    }
}