using System;
using Newtonsoft.Json;

namespace refactor_me.Models
{
	public class ProductOption : IProductOption
	{
		public Guid Id { get; set; }

		public Guid ProductId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		[JsonIgnore]
		public bool IsNew { get; set; }

		public ProductOption()
		{
			Id = Guid.NewGuid();
			IsNew = true;
		}
	}
}