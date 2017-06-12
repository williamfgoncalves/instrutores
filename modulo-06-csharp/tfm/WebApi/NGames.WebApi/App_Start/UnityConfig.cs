using Microsoft.Practices.Unity;
using NGames.Domain.Repositories;
using NGames.Infrastruture.Context;
using NGames.Infrastruture.Repositories;
using System.Web.Http;
using Unity.WebApi;

namespace NGames.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<NGamesDataContext, NGamesDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IClienteRepository, ClienteRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IOpcionalRepository, OpcionalRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPacoteRepository, PacoteRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IProdutoRepository, ProdutoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IReservaRepository, ReservaRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsuarioRepository, UsuarioRepository>(new HierarchicalLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}