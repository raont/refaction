using System;
using System.Collections.Generic;
using refactor_me.Core.Db.Interface;
using refactor_me.Core.Interface;
using refactor_me.Models.Interface;

namespace refactor_me.Core
{
	public class ProductHandler : IProductHandler
	{
		private readonly IProductsRepo _prodRepo;
		private readonly IProductOptionHandler _productOptionHandler;
		private readonly IDbHandler _dbHandler;
		public ProductHandler(IProductsRepo prodRep)
		{
			_prodRepo = prodRep;
			_productOptionHandler = prodRep.GetProductOptionHandler();
			_dbHandler = prodRep.GetDbHandler();
		}

		public void Save(IProduct product)
		{
			 _dbHandler.Execute<IProduct, IDbResult>("SaveProduct", product);
		}

		public void Delete(Guid id)
		{
			foreach (var option in _prodRepo.GetNewProductOptions().WhereProdIdIs(id.ToString()).Items)
				_dbHandler.Execute<Guid, IDbResult>("DeleteProductOp", option.Id);

			_dbHandler.Execute<Guid, IDbResult>("DeleteProduct", id);
		}

		/// <summary>
		/// Gets products from store
		/// </summary>
		/// <returns><see cref="IList{IProduct}"/></returns>
		public IList<IProduct> GetProducts(string name)
		{
			var result = _dbHandler.Execute<string, IResultSet<IProduct>>("Products", name) as IResultSet<IProduct>;
			return result.Items;
		}

		/// <summary>
		/// Gets a product from store based on id <paramref name="id"/>
		/// </summary>
		/// <param name="id">Id of the product</param>
		/// <returns><see cref="IProduct"/></returns>
		public IProduct GetProduct(Guid id)
		{
			var prod = _prodRepo.GetNewProduct();
			var result = _dbHandler.Execute<Guid, IResultSet<IProduct>>("Product", id) as IResultSet<IProduct>;

			return result.Items.Count == 0 ? prod : result.Items[0];
		}
	}
}