using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using refactor_me.Core.Db.Interface;
using refactor_me.Core.Interface;
using refactor_me.Models;
using refactor_me.Models.Interface;

namespace refactor_me.Core
{
	public class ProductOptionHandler : IProductOptionHandler
	{
		private readonly IProductsRepo _prodRepo;
		private readonly IDbHandler _dbHandler;

		public ProductOptionHandler(IProductsRepo prodRep)
		{
			_prodRepo = prodRep;
			_dbHandler = prodRep.GetDbHandler();
		}

		/// <summary>
		/// Save <paramref name="productOption"/> to store
		/// </summary>
		/// <param name="productOption"><see cref="IProductOption"/></param>
		public void Save(IProductOption productOption)
		{
			_dbHandler.Execute<IProductOption, IDbResult>("SaveProductOp", productOption);
		}

		/// <summary>
		/// Delete a product option with <paramref name="id"/>
		/// </summary>
		/// <param name="id"><see cref="Guid"/></param>
		public void Delete(Guid id)
		{
			_dbHandler.Execute<Guid, IDbResult>("DeleteProductOp", id);
		}

		/// <summary>
		/// Gets products from store
		/// </summary>
		/// <returns><see cref="IList{IProduct}"/></returns>
		public IList<IProductOption> GetProductOptions(string prodIdFilter)
		{
			var result = _dbHandler.Execute<string, IResultSet<IProductOption>>("ProductsOp", prodIdFilter) as IResultSet<IProductOption>;
			return result.Items;
		}

		/// <summary>
		/// Gets a <see cref="IProductOption"/> based on <paramref name="id"/> 
		/// </summary>
		/// <param name="id"><see cref="Guid"/></param>
		/// <returns><see cref="IProductOption"/></returns>
		public IProductOption GetProductOption(Guid id)
		{
			var prodOp = _prodRepo.GetNewProductOption();
			var result = _dbHandler.Execute<Guid, IResultSet<IProductOption>>("ProductsOp", id) as IResultSet<IProductOption>;
			return result.Items.Count == 0 ? prodOp : result.Items[0];
		}

		private void PopulateProductOption(SqlDataReader rdr, IProductOption prodOp)
		{
			prodOp.IsNew = false;
			prodOp.Id = Guid.Parse(rdr["Id"].ToString());
			prodOp.ProductId = Guid.Parse(rdr["ProductId"].ToString());
			prodOp.Name = rdr["Name"].ToString();
			prodOp.Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString();
		}
	}
}