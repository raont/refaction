using System.Collections.Generic;

namespace refactor_me.Models.Interface
{
	public interface IProducts
	{
		/// <summary>
		/// Gets the list of products
		/// </summary>
		IList<IProduct> Items { get; }

		/// <summary>
		/// Sets the condition to filter results based on <paramref name="name"/>
		/// </summary>
		/// <param name="name">name filter</param>
		/// <returns><see cref="IProducts"/></returns>
		IProducts WhereNameIs(string name);
	}
}