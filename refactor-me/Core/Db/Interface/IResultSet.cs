using System.Collections.Generic;

namespace refactor_me.Core.Db.Interface
{
	public interface IResultSet<T> : IDbResult
	{
		IList<T> Items { get; set; }
	}
}