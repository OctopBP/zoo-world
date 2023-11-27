using Zenject;
using Zooworld.GameEngine;

namespace Zooworld.Core
{
	public class ServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			InstallEcs();
		}

		private void InstallEcs()
		{
			Container.Bind<IEcsStartup>().To<LeoEcsStartup>().AsSingle();
		}
	}
}
