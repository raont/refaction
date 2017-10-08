using System.Collections.Generic;

namespace refactor_me.Models
{
	public interface IProductOptions
	{
		IList<IProductOption> Items { get; }

		IProductOptions WhereProdIdIs(string productId);
	}
}