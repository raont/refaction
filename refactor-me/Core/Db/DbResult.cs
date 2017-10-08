
using refactor_me.Core.Db.Interface;

namespace refactor_me.Core.Db
{
	/// <summary>
	/// Gets result after a DB operation
	/// </summary>
	public class DbResult : IDbResult
	{
		public Status Status { get; }

		public DbResult(int status)
		{
			Status = status == 0 ? Status.Fail : Status.Success;
		}
	}
}