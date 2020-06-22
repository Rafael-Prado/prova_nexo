using prova_nexo_domain.Domain;
using prova_nexo_repository.Repository.Interface;
using prova_nexo_service.Service.Interface;
using System.Collections.Generic;

namespace prova_nexo_service.Service
{

    public class ClienteService : IClienteService
    {
        readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }
        public Cliente GetClienteId(int id)
        {
            var cliente = _repository.GetClienteId(id);
            return cliente;
        }

        public IEnumerable<Cliente> GetClienteList()
        {
            var cliente = _repository.GetClienteList();
            return cliente;
        }

        public bool SalvarCliente(Cliente cliente)
        {
            var result = _repository.SalvarCliente(cliente);
            return result;
        }
    }
}
