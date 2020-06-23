using prova_nexo_domain.Domain;
using System;
using System.Collections.Generic;

namespace prova_nexo_service.Service.Interface
{
    public interface IProdutoService
    {
        IEnumerable<Produto> GetProdutoIdCliente(Guid clienteId);
        Produto GetProdutoId(Guid id);
        bool SalvarProduto(Produto produtodest);
    }
}
