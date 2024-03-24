using UnityEngine;
using VContainer;
using VContainer.Unity;
using ZooWorld.Game.Units.Collisions;
using ZooWorld.Game.Units.Movement;
using ZooWorld.Game.Units.Views;

namespace ZooWorld.Game.Units.Scope
{
    public class UnitScope : LifetimeScope
    {
        [SerializeField] private UnitView _unitView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.RegisterInstance(_unitView);
            builder.Register<UnitCollisionResolver>(Lifetime.Scoped);
            builder.Register<PoolContainer>(Lifetime.Scoped);
            builder.RegisterEntryPoint<UnitInit>(Lifetime.Scoped);
        }

        protected static void Install<TMovable, TFoodChainResolver>(IContainerBuilder builder)
            where TMovable : IMovable
            where TFoodChainResolver : FoodChainBehaviour 
        {
            builder.Register<IMovable, TMovable>(Lifetime.Scoped);
            builder.Register<FoodChainBehaviour, TFoodChainResolver>(Lifetime.Scoped);
        }
    }
}