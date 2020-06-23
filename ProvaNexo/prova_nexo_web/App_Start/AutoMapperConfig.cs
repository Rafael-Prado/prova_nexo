
using AutoMapper;
using prova_nexo_domain.Domain;
using prova_nexo_web.Models;

namespace prova_nexo_web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Cliente, ClienteModel>();
                cfg.CreateMap<Produto, ProdutoModel>();

                cfg.CreateMap<ClienteModel,Cliente> ();
                cfg.CreateMap<ProdutoModel, Produto>();
            });
        }
    }
}