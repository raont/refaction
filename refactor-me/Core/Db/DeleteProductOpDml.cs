using System;
using System.Data.SqlClient;
using refactor_me.Core.Db.Interface;
using refactor_me.Utils.Interface;

namespace refactor_me.Core.Db
{
	public class DeleteProductOpDml<T> : DmlBase<T>, IDml<T> where T : IDbResult
	{
		private readonly Guid _id;

		public DeleteProductOpDml(Guid id, IHelpers helpers) : base(helpers)
		{
			_id = id;
		}

		public void SetQueryParams()
		{
			Sqlcommand = new SqlCommand($"delete from productoption where id = '{_id}'") {Connection = Conn};
		}
	}
}