using UnityEngine;
using VContainer;
using ZooWorld.Game.Units.Collisions;
using ZooWorld.Game.Units.Movement;
using ZooWorld.Game.Units.Types;
using ZooWorld.Game.Units.Views;

namespace ZooWorld.Game.Units.Scope
{
    public class SnakeScope : UnitScope
    {
        [SerializeField] private PredatorView _predatorView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            
            builder.RegisterInstance(_predatorView);
            builder.RegisterInstance(UnitType.Snake);
            builder.Register<PredatorViewController>(Lifetime.Scoped);
            
            Install<CrawlMovement, PredatorBehaviour>(builder);
        }
    }
}