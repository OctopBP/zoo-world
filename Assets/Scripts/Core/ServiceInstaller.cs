using Zenject;
using Zooworld.GameEngine;

namespace Zooworld.Core
{
	public class ServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindLogService();
			BindEcs();
		}

		private void BindLogService()
		{
			Container.Bind<ILogService>().To<LogService>().AsSingle();
		}

		private void BindEcs()
		{
			Container.Bind<IEcsStartup>().To<LeoEcsStartup>().AsSingle();
		}
	}
}
