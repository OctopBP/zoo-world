using UnityEngine;

namespace ZooWorld.Core
{
    public interface ILog
    {
        void Log(object message, LogType logType = LogType.Log);
    }
}