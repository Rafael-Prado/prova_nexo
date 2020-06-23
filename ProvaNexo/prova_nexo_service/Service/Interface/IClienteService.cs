using prova_nexo_domain.Domain;
using System;
using System.Collections.Generic;

namespace prova_nexo_service.Service.Interface
{
    public interface IClienteService
    {
        IEnumerable<Cliente> GetClienteList();
        Cliente GetClienteId(Guid id);
        bool SalvarCliente(Cliente cliente);
    }
}
