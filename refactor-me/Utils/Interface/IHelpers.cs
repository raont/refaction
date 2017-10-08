using System.Data.SqlClient;

namespace refactor_me.Utils.Interface
{
	public interface IHelpers
	{
		/// <summary>
		/// Gets a connection to DB
		/// </summary>
		/// <returns></returns>
		SqlConnection GetConnection();
	}
}