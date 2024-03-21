using VContainer;
using VContainer.Unity;
using ZooWorld.Game.Units.Collisions;
using ZooWorld.Game.Units.Movement;

namespace ZooWorld.Game.Units.Scope
{
    public class FrogInstaller : UnitInstaller<JumpMovement, PreyBehaviour> { }

    public class SnakeInstaller : UnitInstaller<СrawlMovement, PredatorBehaviour> { }
    
    public class UnitInstaller<TMovable, TFoodChainResolver> : IInstaller
        where TMovable : IMovable
        where TFoodChainResolver : FoodChainBehaviour 
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<IMovable, TMovable>(Lifetime.Scoped);
            builder.Register<FoodChainBehaviour, TFoodChainResolver>(Lifetime.Scoped);;
        }
    }
}