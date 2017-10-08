using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Core.Db.Interface
{
	enum Status {
		Success,
		Fail,
		Rollback
	}

	interface IDbResult
	{
		/// <summary>
		/// Gets the <see cref="Status"/> of the query
		/// </summary>
		Status status { get; }

	}
}
