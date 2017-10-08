using System.Data.SqlClient;
using System.Web;
using refactor_me.Utils.Interface;

namespace refactor_me.Utils
{
	public class Helpers : IHelpers
	{
		private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DataDirectory}\Database.mdf;Integrated Security=True";

		public SqlConnection GetConnection()
		{
			var connstr = ConnectionString.Replace("{DataDirectory}", HttpContext.Current.Server.MapPath("~/App_Data"));
			return new SqlConnection(connstr);
		}
	}
}