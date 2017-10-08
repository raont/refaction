using System;
using System.Data.SqlClient;
using refactor_me.Core.Db.Interface;
using refactor_me.Models;
using refactor_me.Models.Interface;

namespace refactor_me.Core.Db
{
	public class DbHelper : IDbHelper
	{
		/// <summary>
		/// Populate a <paramref name="prod"/> from <paramref name="rdr"/>
		/// </summary>
		/// <param name="rdr"><see cref="SqlDataReader"/></param>
		/// <param name="prod"><see cref="IProduct"/></param>
		public void PopulateProduct(SqlDataReader rdr, IProduct prod)
		{
			prod.IsNew = false;
			prod.Id = Guid.Parse(rdr["Id"].ToString());
			prod.Name = rdr["Name"].ToString();
			prod.Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString();
			prod.Price = decimal.Parse(rdr["Price"].ToString());
			prod.DeliveryPrice = decimal.Parse(rdr["DeliveryPrice"].ToString());
		}

		/// <summary>
		/// Populate a <paramref name="prodOp"/> from <paramref name="rdr"/>
		/// </summary>
		/// <param name="rdr"><see cref="SqlDataReader"/></param>
		/// <param name="prodOp"><see cref="IProductOption"/></param>
		public void PopulateProductOp(SqlDataReader rdr, IProductOption prodOp)
		{
			prodOp.IsNew = false;
			prodOp.Id = Guid.Parse(rdr["Id"].ToString());
			prodOp.ProductId = Guid.Parse(rdr["ProductId"].ToString());
			prodOp.Name = rdr["Name"].ToString();
			prodOp.Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString();
		}
	}
}