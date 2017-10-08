using System;
using Newtonsoft.Json;

namespace refactor_me.Models
{
	public interface IProductOption
	{
		string Description { get; set; }
		Guid Id { get; set; }

		[JsonIgnore]
		bool IsNew { get; set; }
		string Name { get; set; }
		Guid ProductId { get; set; }
	}
}