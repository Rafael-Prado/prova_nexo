using System;
using prova_nexo_domain.Domain;
using prova_nexo_infra.Context;
using prova_nexo_repository.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace prova_nexo_repository.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ProvaNexoContext _context;

        public ClienteRepository(ProvaNexoContext context)
        {
            _context = context;
        }

        public Cliente GetClienteId(Guid id)
        {
            var cliente = _context.Cliente
                .FirstOrDefault(c => c.Id == id);
            return cliente;
        }

        public IEnumerable<Cliente> GetClienteList()
        {
            var clietes = _context.Cliente.AsEnumerable();
            return clietes;
        }

        public bool SalvarCliente(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
            return true;
        }
    }



}
