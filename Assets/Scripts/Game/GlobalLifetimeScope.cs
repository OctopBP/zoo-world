using VContainer;
using VContainer.Unity;
using ZooWorld.Core;

namespace ZooWorld.Game
{
    public class GlobalLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ILog, UnityLogger>(Lifetime.Singleton);
            builder.Register<ISceneLoader, SimpleSceneLoader>(Lifetime.Singleton);
            builder.Register<IRnd, Random>(Lifetime.Singleton);
            builder.Register<IAssetProvider, AssetProvider>(Lifetime.Singleton);
        }
    }
}
