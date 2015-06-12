using Microsoft.Practices.Unity;
using System.Web.Http;
using Ductia.Web.Controllers;
using Unity.WebApi;

namespace Ductia.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IBookRepository, BookRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}