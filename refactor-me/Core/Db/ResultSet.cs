using System.Collections.Generic;
using refactor_me.Core.Db.Interface;
using refactor_me.Models.Interface;

namespace refactor_me.Core.Db
{
	public class ResultSet<T> : IResultSet<T>
	{
		public ResultSet(Status status)
		{
			Status = status;
			Items = new List<T>();
		}

		public Status Status { get; private set; }

		public IList<T> Items { get; set; }
	}
}