using prova_nexo_domain.Domain;
using prova_nexo_repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using prova_nexo_infra.Context;

namespace prova_nexo_repository.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProvaNexoContext _context;

        public ProdutoRepository(ProvaNexoContext context)
        {
            _context = context;
        }

        public Produto GetProdutoId(Guid id)
        {
            var produto = _context.Produto.FirstOrDefault(p => p.Id == id);
            return produto;
        }

        public IEnumerable<Produto> GetProdutoIdCliente(Guid clienteId)
        {
            var produtos = _context.Produto.ToList().Where(p => p.ClienteId == clienteId);
            return produtos;
        }

        public bool SalvarProduto(Produto produtodest)
        {
            _context.Produto.Add(produtodest);
            _context.SaveChanges();
            return true;
        }

        public bool ExiteProdutoIdCliente(Guid produtodestClienteId, string produtodestNome)
        {
            return _context.Produto.Any(p => p.ClienteId == produtodestClienteId & p.Nome == produtodestNome);
        }
    }
}
