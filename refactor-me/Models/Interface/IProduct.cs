using System;

namespace refactor_me.Models.Interface
{
	public interface IProduct
	{
		decimal DeliveryPrice { get; set; }
		string Description { get; set; }
		Guid Id { get; set; }
		bool IsNew { get; set; }
		string Name { get; set; }
		decimal Price { get; set; }
	}
}