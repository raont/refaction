using System.Data.SqlClient;
using refactor_me.Core.Db.Interface;
using refactor_me.Models;
using refactor_me.Models.Interface;
using refactor_me.Utils.Interface;

namespace refactor_me.Core.Db
{
	public class SaveProductOpDml<T> : DmlBase<T>, IDml<T> where T : IDbResult
	{
		private readonly IProductOption _productOp;
		
		public SaveProductOpDml(IProductOption productOp, IHelpers helper) : base(helper)
		{
			_productOp = productOp;
		}

		/// <summary>
		/// Sets the parameter for the query
		/// </summary>
		public void SetQueryParams()
		{
			Sqlcommand = _productOp.IsNew ?
				new SqlCommand($"insert into productoption (id, productid, name, description) values ('{_productOp.Id}', '{_productOp.ProductId}', '{_productOp.Name}', '{_productOp.Description}')") :
				new SqlCommand($"update productoption set name = '{_productOp.Name}', description = '{_productOp.Description}' where id = '{_productOp.Id}'");
			Sqlcommand.Connection = Conn;
		}
	}
}