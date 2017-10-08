namespace refactor_me.Core.Db.Interface
{
	public enum Status {
		Success,
		Fail,
	}

	public interface IDbResult
	{
		/// <summary>
		/// Gets the <see cref="Interface.Status"/> of the query
		/// </summary>
		Status Status { get; }

	}
}
