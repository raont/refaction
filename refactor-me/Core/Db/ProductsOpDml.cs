
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using refactor_me.Core.Db.Interface;
using refactor_me.Core.Interface;
using refactor_me.Models;
using refactor_me.Models.Interface;
using refactor_me.Utils.Interface;

namespace refactor_me.Core.Db
{
	public class ProductsOpDml<T> : DmlBase<T>, IDml<T> where T : IDbResult
	{
		private readonly string _prodIdFilter;
		private readonly IProductsRepo _prodRepo;
		private readonly IDbHelper _dbHelper;
		private SqlDataReader result;

		public ProductsOpDml(string id, IProductsRepo prodRep, IHelpers helper) : base(helper)
		{
			_prodIdFilter = string.IsNullOrEmpty(id) ? string.Empty : $"where productid = '{id}'";
			_prodRepo = prodRep;
			_dbHelper = prodRep.GetDbHelper();
		}

		public void SetQueryParams()
		{
			Sqlcommand = new SqlCommand($"select id from productoption {_prodIdFilter}") {Connection = Conn};
		}

		public override void Execute()
		{
			Conn.Open();
			result = Sqlcommand.ExecuteReader();
		}

		public override IDbResult GetResult()
		{
			var prodResult = _prodRepo.GetProdResult<IProductOption>(Status.Success);
			while (result.Read())
			{
				var prod = _prodRepo.GetNewProductOption();
				_dbHelper.PopulateProductOp(result, prod);
				prodResult.Items.Add(prod);
			}

			return (T)prodResult;
		}
	}
}