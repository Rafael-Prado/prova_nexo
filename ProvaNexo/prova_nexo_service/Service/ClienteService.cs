using System;
using prova_nexo_domain.Domain;
using prova_nexo_repository.Repository.Interface;
using prova_nexo_service.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace prova_nexo_service.Service
{

    public class ClienteService : IClienteService
    {
        readonly IClienteRepository _repository;
        private readonly IProdutoRepository _produtoRepository;

        public ClienteService(IClienteRepository repository, IProdutoRepository produtoRepository)
        {
            _repository = repository;
            _produtoRepository = produtoRepository;
        }
        public Cliente GetClienteId(Guid id)
        {
            var cliente = _repository.GetClienteId(id);
            if (cliente != null)
            {
                cliente.ProdutoList = _produtoRepository.GetProdutoIdCliente(cliente.Id).ToList();
            }
            return cliente;
        }

        public IEnumerable<Cliente> GetClienteList()
        {
            var cliente = _repository.GetClienteList();
            return cliente;
        }

        public bool SalvarCliente(Cliente cliente)
        {
            cliente.Id = Guid.NewGuid();
            var result = _repository.SalvarCliente(cliente);
            return result;
        }
    }
}
