using System;

namespace Zooworld.GameEngine
{
	public interface IEcsStartup : IDisposable
	{
		void Update();
	}
}