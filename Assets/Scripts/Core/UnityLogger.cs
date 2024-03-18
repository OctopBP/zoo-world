using UnityEngine;

namespace ZooWorld.Core
{
    public class UnityLogger : ILog
    {
        public void Log(object message, LogType logType)
        {
#if UNITY_EDITOR
            Debug.unityLogger.Log(LogType.Log, message);
#endif
        }
    }
}