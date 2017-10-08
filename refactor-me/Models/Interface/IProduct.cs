using System;
using Newtonsoft.Json;

namespace refactor_me.Models.Interface
{
	public interface IProduct
	{
		decimal DeliveryPrice { get; set; }
		string Description { get; set; }
		Guid Id { get; set; }

		[JsonIgnore]
		bool IsNew { get; set; }
		string Name { get; set; }
		decimal Price { get; set; }
	}
}