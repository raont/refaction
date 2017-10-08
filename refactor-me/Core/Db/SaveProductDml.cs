using System.Data.SqlClient;
using refactor_me.Core.Db.Interface;
using refactor_me.Models.Interface;
using refactor_me.Utils.Interface;

namespace refactor_me.Core.Db
{
	public class SaveProductDml<T> : DmlBase<T>, IDml<T> where T : IDbResult
	{
		private readonly IProduct _product;
		
		public SaveProductDml(IProduct product, IHelpers helper) : base(helper)
		{
			_product = product;
		}

		/// <summary>
		/// Sets the parameter for the query
		/// </summary>
		public void SetQueryParams()
		{
			Sqlcommand = _product.IsNew 
						? new SqlCommand($"insert into product (id, name, description, price, deliveryprice) values ('{_product.Id}', '{_product.Name}', '{_product.Description}', {_product.Price}, {_product.DeliveryPrice})")
						: new SqlCommand($"update product set name = '{_product.Name}', description = '{_product.Description}', price = {_product.Price}, deliveryprice = {_product.DeliveryPrice} where id = '{_product.Id}'");
			Sqlcommand.Connection = Conn;
		}
	}
}