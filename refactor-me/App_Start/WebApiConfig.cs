using System.Web.Http;
using refactor_me.Core;
using refactor_me.Core.Interface;

namespace refactor_me
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
			var formatters = GlobalConfiguration.Configuration.Formatters;
			formatters.Remove(formatters.XmlFormatter);
			formatters.JsonFormatter.Indent = true;

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			var ioc = new Ioc(x => x.AddRegistry<AppRegistry>());
			config.DependencyResolver = ioc;
			var prodRepo = ioc.GetService(typeof(IProductsRepo)) as IProductsRepo;
			prodRepo.Initilize(ioc);
		}
	}
}
