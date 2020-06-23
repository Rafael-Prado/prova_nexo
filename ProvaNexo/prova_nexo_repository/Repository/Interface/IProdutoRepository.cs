using prova_nexo_domain.Domain;
using System;
using System.Collections.Generic;

namespace prova_nexo_repository.Repository.Interface
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> GetProdutoIdCliente(Guid clienteId);
        Produto GetProdutoId(Guid id);
        bool SalvarProduto(Produto produtodest);
        bool ExiteProdutoIdCliente(Guid produtodestClienteId, string produtodestNome);
    }
}
