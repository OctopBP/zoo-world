using Zenject;
using Zooworld.Core.States;
using Zooworld.Game;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameBootstrap>().AsSingle();
        Container.Bind<IStateMachine>().To<GameStateMachine>().AsSingle();
    }
}