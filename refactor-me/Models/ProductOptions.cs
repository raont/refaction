using System.Collections.Generic;
using refactor_me.Core.Interface;

namespace refactor_me.Models
{
	public class ProductOptions : IProductOptions
	{
		private string _prodIdFilter;
		private readonly IProductOptionHandler _prodOpHandler;

		/// <summary>
		/// Gets the list of products
		/// </summary>
		public IList<IProductOption> Items => _prodOpHandler.GetProductOptions(_prodIdFilter);

		public ProductOptions(IProductOptionHandler prodOpHandler)
		{
			_prodOpHandler = prodOpHandler;
			_prodIdFilter = string.Empty;
		}

		/// <summary>
		/// Sets the condition to filter results based on <paramref name="name"/>
		/// </summary>
		/// <param name="productId">product id filter</param>
		/// <returns><see cref="ProductOptions"/></returns>
		public IProductOptions WhereProdIdIs(string productId)
		{
			_prodIdFilter = productId;
			return this;
		}
	}
}
