using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using refactor_me.Core.Db.Interface;
using refactor_me.Core.Interface;

namespace refactor_me.Core.Db
{
	/// <summary>
	/// Handles DB commands and executions
	/// </summary>
	public class DbHandler : IDbHandler
	{
		private readonly IProductsRepo _prodRepo;

		public DbHandler(IProductsRepo prodRepo)
		{
			_prodRepo = prodRepo;
		}

		public IDbResult Execute<T, R>(string dmlName, T param) where R : IDbResult
		{
			var dml = _prodRepo.GetDml<T, R>(dmlName, param);
			dml.SetQueryParams();
			dml.Execute();
			return dml.GetResult();
		}
	}
}