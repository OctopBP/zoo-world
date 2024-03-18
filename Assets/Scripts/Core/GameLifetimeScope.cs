using VContainer;
using VContainer.Unity;

namespace ZooWorld.Core
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ILog, UnityLogger>(Lifetime.Singleton);
            builder.Register<ISceneLoader, SimpleSceneLoader>(Lifetime.Singleton);
        }
    }
}
