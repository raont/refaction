using System.Data;

namespace refactor_me.Core.Db.Interface
{
	interface IDml<T> where T : IDbResult
	{
		/// <summary>
		/// Executes a particulare DML query
		/// </summary>
		void Execute();

		/// <summary>
		/// Gets the description of DML query for logging purposes
		/// </summary>
		string Description { get; }

		/// <summary>
		/// Gets the result after executing the DML
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		T GetResult(IDbCommand command);
	}
}
