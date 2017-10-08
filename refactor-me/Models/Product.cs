using System;
using System.Data.SqlClient;
using Newtonsoft.Json;
using refactor_me.Models.Interface;

namespace refactor_me.Models
{
	public class Product : IProduct
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }

		public decimal DeliveryPrice { get; set; }

		[JsonIgnore]
		public bool IsNew { get; set; }

		public Product()
		{
			Id = Guid.NewGuid();
			IsNew = true;
		}
	}
}