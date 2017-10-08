using System.Web.Http.Dependencies;
using refactor_me.Models;
using refactor_me.Models.Interface;

namespace refactor_me.Core.Interface
{
	/// <summary>
	/// Repository of all the objects needed for a processing products
	/// </summary>
	public interface IProductsRepo
	{
		/// <summary>
		/// Gets instance of <see cref="IProductHandler"/>
		/// </summary>
		/// <returns></returns>
		IProductHandler GetProductHandler();

		/// <summary>
		/// Gets instance of <see cref="IProductOptionHandler"/>
		/// </summary>
		/// <returns></returns>
		IProductOptionHandler GetProductOptionHandler();

		/// <summary>
		/// Creates a new instance of <see cref="IProduct"/>
		/// </summary>
		/// <returns><see cref="IProduct"/></returns>
		IProduct GetNewProduct();

		/// <summary>
		/// Creates a new instance of <see cref="IProducts"/>
		/// </summary>
		/// <returns><see cref="IProduct"/></returns>
		IProducts GetNewProducts();

		/// <summary>
		/// Creates a new instance of <see cref="IProductOption"/>
		/// </summary>
		/// <returns><see cref="IProductOption"/></returns>
		IProductOption GetNewProductOption();

		/// <summary>
		/// Creates a new instance of <see cref="IProductOptions"/>
		/// </summary>
		/// <returns><see cref="IProductOptions"/></returns>
		IProductOptions GetNewProductOptions();

		void Initilize(IDependencyResolver ioc);
	}
}
