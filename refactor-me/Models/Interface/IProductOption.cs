using System;

namespace refactor_me.Models
{
	public interface IProductOption
	{
		string Description { get; set; }
		Guid Id { get; set; }
		bool IsNew { get; set; }
		string Name { get; set; }
		Guid ProductId { get; set; }
	}
}