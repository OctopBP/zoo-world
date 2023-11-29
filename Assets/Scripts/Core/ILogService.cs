namespace Zooworld.Core
{
	public interface ILogService
	{
		void Log(object message);
		void LogError(object message);
	}
}