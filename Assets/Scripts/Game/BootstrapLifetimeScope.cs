using VContainer;
using VContainer.Unity;

namespace ZooWorld.Game
{
    public class BootstrapLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<Bootstrap>();
        }
    }
}
