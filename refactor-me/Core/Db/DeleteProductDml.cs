using System;
using System.Data.SqlClient;
using refactor_me.Core.Db.Interface;
using refactor_me.Utils.Interface;

namespace refactor_me.Core.Db
{
	public class DeleteProductDml<T> : DmlBase<T>, IDml<T> where T : IDbResult
	{

		private readonly Guid _id;

		public DeleteProductDml(Guid id, IHelpers helpers) : base(helpers)
		{
			_id = id;
		}

		public void SetQueryParams()
		{
			Sqlcommand = new SqlCommand($"delete from product where id = '{_id}'") {Connection = Conn};
		}
	}
}