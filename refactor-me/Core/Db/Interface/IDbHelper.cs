using System.Data.SqlClient;
using refactor_me.Models;
using refactor_me.Models.Interface;

namespace refactor_me.Core.Db.Interface
{
	public interface IDbHelper
	{
		void PopulateProduct(SqlDataReader rdr, IProduct prod);
		void PopulateProductOp(SqlDataReader rdr, IProductOption prodOp);
	}
}