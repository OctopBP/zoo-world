using UnityEngine;
using VContainer;
using ZooWorld.Game.Units.Scope;
using ZooWorld.Game.Units.Views;

namespace ZooWorld.Game.Units
{
    public class SnakeScope : UnitScope
    {
        [SerializeField] private PredatorView _predatorView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.Register<PredatorViewController>(Lifetime.Scoped);
            builder.RegisterInstance(_predatorView);
        }
    }
}