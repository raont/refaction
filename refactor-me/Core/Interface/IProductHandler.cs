using System;
using System.Collections.Generic;
using refactor_me.Models.Interface;

namespace refactor_me.Core.Interface
{
	public interface IProductHandler
	{
		/// <summary>
		/// Deletes a product
		/// </summary>
		/// <param name="id"><see cref="Guid"/> of <see cref="IProduct"/> to be deleted</param>
		void Delete(Guid id);

		/// <summary>
		/// Saves or updates a <paramref name="product"/>
		/// </summary>
		/// <param name="product"><see cref="IProduct"/> to be saved</param>
		void Save(IProduct product);

		/// <summary>
		/// Gets products from store
		/// </summary>
		/// <returns><see cref="IList{T}"/></returns>
		IList<IProduct> GetProducts(string nameFilter);

		/// <summary>
		/// Gets a product from store based on id <paramref name="id"/>
		/// </summary>
		/// <param name="id">Id of the product</param>
		/// <returns><see cref="IProduct"/></returns>
		IProduct GetProduct(Guid id);
	}
}