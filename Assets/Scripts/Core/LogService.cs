using UnityEngine;

namespace Zooworld.Core
{
	public class LogService : ILogService
	{
		public void Log(object message) => Debug.Log(message);
		public void LogError(object message) => Debug.LogError(message);
	}
}