using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using refactor_me.Core.Db.Interface;
using refactor_me.Core.Interface;
using refactor_me.Models.Interface;
using refactor_me.Utils.Interface;

namespace refactor_me.Core.Db
{
	public class ProductDml<T> : DmlBase<T>, IDml<T> where T : IDbResult
	{
		private readonly string _id;
		private readonly IProductsRepo _prodRepo;
		private readonly IDbHelper _dbHelper;
		private SqlDataReader _result;

		public ProductDml(string id, IProductsRepo prodRep, IHelpers helper) : base(helper)
		{
			_id = id;
			_prodRepo = prodRep;
			_dbHelper = prodRep.GetDbHelper();
		}

		public void SetQueryParams()
		{
			Sqlcommand = new SqlCommand($"select * from product where id = '{_id}'") {Connection = Conn};
		}

		public override void Execute()
		{
			Conn.Open();
			_result = Sqlcommand.ExecuteReader();
		}

		public override IDbResult GetResult()
		{
			var prodResult = _prodRepo.GetProdResult<IProduct>(Status.Success);
			while (_result.Read())
			{
				var prod = _prodRepo.GetNewProduct();
				_dbHelper.PopulateProduct(_result, prod);
				prodResult.Items.Add(prod);
			}

			return (T)prodResult;
		}
	}
}