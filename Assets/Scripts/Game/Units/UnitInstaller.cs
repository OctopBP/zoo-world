using VContainer;
using VContainer.Unity;
using ZooWorld.Game.Units.Movement;

namespace ZooWorld.Game.Units
{
    public class FrogInstaller : UnitInstaller<JumpMovement> { }
    public class SnakeInstaller : UnitInstaller<СrawlMovement> { }
    
    public class UnitInstaller<TMovable> : IInstaller where TMovable : IMovable
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<IMovable, TMovable>(Lifetime.Scoped);
        }
    }
}