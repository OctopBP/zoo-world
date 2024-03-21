using UnityEngine;
using VContainer;
using VContainer.Unity;
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
            builder.RegisterEntryPoint<UnitInit>(Lifetime.Scoped);
        }
    }
}