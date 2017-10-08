using System;
using System.Collections.Generic;
using refactor_me.Models;

namespace refactor_me.Core.Interface
{
	public interface IProductOptionHandler
	{
		/// <summary>
		/// Gets products from store
		/// </summary>
		/// <returns><see cref="IList{IProduct}"/></returns>
		IList<IProductOption> GetProductOptions(string nameFilter);

		/// <summary>
		/// Gets a <see cref="IProductOption"/> based on <paramref name="id"/> 
		/// </summary>
		/// <param name="id"><see cref="Guid"/></param>
		/// <returns><see cref="IProductOption"/></returns>
		IProductOption GetProductOption(Guid id);

		/// <summary>
		/// Save <paramref name="productOption"/> to store
		/// </summary>
		/// <param name="productOption"><see cref="IProductOption"/></param>
		void Save(IProductOption productOption);

		/// <summary>
		/// Delete a product option with <paramref name="id"/>
		/// </summary>
		/// <param name="id"><see cref="Guid"/></param>
		void Delete(Guid id);
	}
}