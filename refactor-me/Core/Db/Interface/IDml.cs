using System.Data;

namespace refactor_me.Core.Db.Interface
{
	public interface IDml<T> where T : IDbResult
	{
		/// <summary>
		/// Executes a particulare DML query
		/// </summary>
		void Execute();

		/// <summary>
		/// Gets the result after executing the DML
		/// </summary>
		/// <returns></returns>
		IDbResult GetResult();

		/// <summary>
		/// Sets the parameter for the query
		/// </summary>
		void SetQueryParams();
	}
}
