using prova_nexo_service.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prova_nexo_domain.Domain;
using prova_nexo_repository.Repository.Interface;

namespace prova_nexo_service.Service
{
    public class ProdutoService: IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Produto> GetProdutoIdCliente(Guid clienteId)
        {
            var resut = _repository.GetProdutoIdCliente(clienteId);
            return resut;
        }

        public Produto GetProdutoId(Guid id)
        {
            var result = _repository.GetProdutoId(id);
            return result;
        }

        public bool SalvarProduto(Produto produtodest)
        {
            if (_repository.ExiteProdutoIdCliente(produtodest.ClienteId, produtodest.Nome))
            {
                return false;
            }
            produtodest.Id = Guid.NewGuid();
            var result = _repository.SalvarProduto(produtodest);
            return true;
        }
    }
}
