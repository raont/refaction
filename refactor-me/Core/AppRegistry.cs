using System.Web.Http.Dependencies;
using refactor_me.Controllers;
using refactor_me.Core.Db;
using refactor_me.Core.Db.Interface;
using refactor_me.Core.Interface;
using refactor_me.Models;
using refactor_me.Models.Interface;
using refactor_me.Utils;
using refactor_me.Utils.Interface;
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
			For<IProductOptionHandler>().Singleton().Use<ProductOptionHandler>();
			For<ProductsController>().Use<ProductsController>();
			For<IProductsRepo>().Singleton().Use<ProductsRepo>();
			For<IProducts>().Singleton().Use<Products>();
			For<IProduct>().Singleton().Use<Product>();
			For<IHelpers>().Singleton().Use<Helpers>();
			For<IDbHandler>().Singleton().Use<DbHandler>();
			For<IDbHelper>().Singleton().Use<DbHelper>();
			For<IProductOptions>().Use<ProductOptions>();
			For<IProductOption>().Use<ProductOption>();
			For<IResultSet<IProduct>>().Use<ResultSet<IProduct>>();
			For<IResultSet<IProductOption>>().Use<ResultSet<IProductOption>>();
			
			//Dml wiring
			For<IDml<IDbResult>>().Use<SaveProductDml<IDbResult>>().Named("SaveProduct");
			For<IDml<IDbResult>>().Use<DeleteProductDml<IDbResult>>().Named("DeleteProduct");
			For<IDml<IResultSet<IProduct>>>().Use<ProductsDml<IResultSet<IProduct>>>().Named("Products");
			For<IDml<IResultSet<IProduct>>>().Use<ProductDml<IResultSet<IProduct>>>().Named("Product");

			For<IDml<IDbResult>>().Use<SaveProductOpDml<IDbResult>>().Named("SaveProductOp");
			For<IDml<IDbResult>>().Use<DeleteProductOpDml<IDbResult>>().Named("DeleteProductOp");
			For<IDml<IResultSet<IProductOption>>>().Use<ProductsOpDml<IResultSet<IProductOption>>>().Named("ProductsOp");
			For<IDml<IResultSet<IProduct>>>().Use<ProductOpDml<IResultSet<IProduct>>>().Named("ProductOp");
		}
	}
}