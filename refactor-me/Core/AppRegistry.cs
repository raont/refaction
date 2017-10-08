using System.Web.Http.Dependencies;
using refactor_me.Controllers;
using refactor_me.Core.Interface;
using refactor_me.Models;
using refactor_me.Models.Interface;
using StructureMap.Configuration.DSL;

namespace refactor_me.Core
{
	/// <summary>
	/// Ioc class for wiring all the DI classes in this Application
	/// Uses structureMap for Ioc
	/// </summary>
	public class AppRegistry : Registry
	{
		public AppRegistry()
		{
			For<IProductHandler>().Singleton().Use<ProductHandler>();
			For<ProductsController>().Use<ProductsController>();
			For<IProductsRepo>().Singleton().Use<ProductsRepo>();
			For<IProducts>().Singleton().Use<Products>();
			For<IProduct>().Singleton().Use<Product>();
		}
	}
}