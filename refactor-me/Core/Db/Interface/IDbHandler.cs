namespace refactor_me.Core.Db.Interface
{
	public interface IDbHandler
	{
		IDbResult Execute<T, R>(string dmlName, T param) where R : IDbResult;
	}
}