using Dapper;
using prova_nexo_domain.Domain;
using prova_nexo_infra.Context;
using prova_nexo_infra.Shared;
using prova_nexo_repository.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace prova_nexo_repository.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private ProvaNexoContext dbSet;

        public Cliente GetClienteId(int id)
        {
            var sql = $@"Select *from cliente where Id = {id}";

           return Runtime.Query<Cliente>(sql).FirstOrDefault();

        }

        public IEnumerable<Cliente> GetClienteList()
        {
            var sql = $@"Select *from Cliente ";

            return Runtime.Query<Cliente>(sql);
        }

        public bool SalvarCliente(Cliente cliente)
        {
           
            return true;
        }
    }


   
}
