using VContainer;
using ZooWorld.Game.Units.Collisions;
using ZooWorld.Game.Units.Movement;
using ZooWorld.Game.Units.Types;

namespace ZooWorld.Game.Units.Scope
{
    public class FrogScope : UnitScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.RegisterInstance(UnitType.Frog);
            Install<JumpMovement, PreyBehaviour>(builder);
        }
    }
}