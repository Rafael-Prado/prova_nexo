﻿


using prova_nexo_domain.Domain;
using System.Collections.Generic;

namespace prova_nexo_repository.Repository.Interface
{
    public interface IClienteRepository
    {
        Cliente GetClienteId(int id);
        IEnumerable<Cliente> GetClienteList();
        bool SalvarCliente(Cliente cliente);
    }
}
