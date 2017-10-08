using System.Data.SqlClient;
using refactor_me.Core.Db.Interface;
using refactor_me.Utils.Interface;

namespace refactor_me.Core.Db
{
	public class DmlBase<T> where T : IDbResult
	{
		protected readonly SqlConnection Conn;
		protected SqlCommand Sqlcommand;

		private int _resultCode;

		protected DmlBase(IHelpers helper)
		{
			Conn = helper.GetConnection();
		}

		public virtual void Execute()
		{
			Conn.Open();
			_resultCode = Sqlcommand.ExecuteNonQuery();
		}

		public virtual IDbResult GetResult()
		{
			var result = new DbResult(_resultCode);
			return result;
		}
	}
}