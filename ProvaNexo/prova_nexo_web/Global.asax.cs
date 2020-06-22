
using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using prova_nexo_infra.Shared;
using prova_nexo_web.App_Start;
using prova_nexo_web.Mappers;

namespace prova_nexo_web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMappings();


            IocConfig.ConfigurarDependencias();

            Runtime.ConnectionStringConfig = ConfigurationManager.ConnectionStrings["PROVANEXOCONTEXT"].ConnectionString;
        }
    }
}
