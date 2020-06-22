using System;
using System.Collections.Generic;
using Ninject;
using Ninject.Syntax;
using System.Web.Mvc;
using prova_nexo_repository.Repository;
using prova_nexo_repository.Repository.Interface;
using prova_nexo_service.Service.Interface;
using prova_nexo_service.Service;

namespace prova_nexo_web.App_Start
{
    public class IocConfig
    {
        public static void ConfigurarDependencias()
        {
            //Cria o Container 
            IKernel kernel = new StandardKernel();

            //Services
            kernel.Bind<IProdutoService>().To<ProdutoService>();
            kernel.Bind<IClienteService>().To<ClienteService>();

            //Repositorys
            kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();
            kernel.Bind<IClienteRepository>().To<ClienteRepository>();

            //Registra o container no ASP.NET
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IResolutionRoot _resolutionRoot;

        public NinjectDependencyResolver(IResolutionRoot kernel)
        {
            _resolutionRoot = kernel;
        }

        public object GetService(Type serviceType)
        {
            return _resolutionRoot.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolutionRoot.GetAll(serviceType);
        }
    }
}