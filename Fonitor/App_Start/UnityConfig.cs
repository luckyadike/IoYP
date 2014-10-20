namespace Fonitor
{
	using Fonitor.Services;
	using Microsoft.Practices.Unity;
	using System.Web.Http;
	using Unity.WebApi;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

			container.RegisterType<IAPIKeyProvider, SimpleAPIKeyProvider>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}