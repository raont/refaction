using System.EnterpriseServices.Internal;
using System.Web.Http.Dependencies;
using refactor_me.Core.Db;
using refactor_me.Core.Db.Interface;
using refactor_me.Core.Interface;
using refactor_me.Models;
using refactor_me.Models.Interface;

namespace refactor_me.Core
{
	public class ProductsRepo : IProductsRepo
	{
		private IIoc _iocResolver;

		public void Initilize(IIoc ioc)
		{
			_iocResolver = ioc;
		}

		/// <summary>
		/// Gets instance of <see cref="IProductHandler"/>
		/// </summary>
		/// <returns></returns>
		public IProductHandler GetProductHandler()
		{
			return _iocResolver.GetService(typeof(IProductHandler)) as IProductHandler;
		}

		/// <summary>
		/// Gets instance of <see cref="IProductOptionHandler"/>
		/// </summary>
		/// <returns></returns>
		public IProductOptionHandler GetProductOptionHandler()
		{
			return _iocResolver.GetService(typeof(IProductOptionHandler)) as IProductOptionHandler;
		}

		/// <summary>
		/// Creates a new instance of <see cref="IProduct"/>
		/// </summary>
		/// <returns><see cref="IProduct"/></returns>
		public IProduct GetNewProduct()
		{
			var prod = _iocResolver.GetService(typeof(IProduct)) as IProduct;
			prod.IsNew = true;
			return prod;
		}

		/// <summary>
		/// Creates a new instance of <see cref="IProducts"/>
		/// </summary>
		/// <returns><see cref="IProduct"/></returns>
		public IProducts GetNewProducts()
		{
			return _iocResolver.GetService(typeof(IProducts)) as IProducts;
		}

		/// <summary>
		/// Creates a new instance of <see cref="IProductOption"/>
		/// </summary>
		/// <returns><see cref="IProductOption"/></returns>
		public IProductOption GetNewProductOption()
		{
			var prodOption = _iocResolver.GetService(typeof(IProductOption)) as IProductOption;
			prodOption.IsNew = true;
			return prodOption;
		}

		/// <summary>
		/// Creates a new instance of <see cref="IProductOptions"/>
		/// </summary>
		/// <returns><see cref="IProductOptions"/></returns>
		public IProductOptions GetNewProductOptions()
		{
			return _iocResolver.GetService(typeof(IProductOptions)) as IProductOptions;
		}

		/// <summary>
		/// Gets an instance of the dmls based on the <paramref name="dml"/> name
		/// </summary>
		/// <returns><see cref="IProductOptions"/></returns>
		public IDml<R> GetDml<T, R>(string dml, T param) where R : IDbResult
		{
			return _iocResolver.Repo.With<T>(param).GetInstance<IDml<R>>(dml);
		}

		/// <summary>
		/// Gets an instance of the dbHandler
		/// </summary>
		/// <returns><see cref="IDbHandler"/></returns>
		public IDbHandler GetDbHandler()
		{
			return _iocResolver.Repo.GetInstance<IDbHandler>();
		}

		/// <summary>
		/// Gets an instance of the <see cref="IResultSet"/>
		/// </summary>
		/// <returns><see cref="IResultSet"/></returns>
		public IResultSet<T> GetProdResult<T>(Status status)
		{
			return _iocResolver.Repo.With(status).GetInstance<IResultSet<T>>();
		}

		/// <summary>
		/// Gets an instance of the <see cref="IDbHelper"/>
		/// </summary>
		/// <returns><see cref="IDbHelper"/></returns>
		public IDbHelper GetDbHelper()
		{
			return _iocResolver.Repo.GetInstance<IDbHelper>();
		}
	}
}