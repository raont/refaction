using System.Collections.Generic;
using refactor_me.Core.Interface;
using refactor_me.Models.Interface;

namespace refactor_me.Models
{
	/// <summary>
	/// Model for Products
	/// </summary>
	public class Products : IProducts
	{
		private string _nameFilter;
		private readonly IProductHandler _prodHandler;

		/// <summary>
		/// Gets the list of products
		/// </summary>
		public IList<IProduct> Items => _prodHandler.GetProducts(_nameFilter);

		public Products(IProductHandler prodHandler)
		{
			_prodHandler = prodHandler;
			_nameFilter = string.Empty;
		}

		/// <summary>
		/// Sets the condition to filter results based on <paramref name="name"/>
		/// </summary>
		/// <param name="name">name filter</param>
		/// <returns><see cref="IProducts"/></returns>
		public IProducts WhereNameIs(string name)
		{
			_nameFilter = $"where lower(name) like '%{name.ToLower()}%'";
			return this;
		}
	}
}