using UnityEngine;
using VContainer;
using VContainer.Unity;
using ZooWorld.Game.Gameplay;
using ZooWorld.Game.Units;

namespace ZooWorld.Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private Data.Assets _assets;
        [SerializeField] private Data.Config _config;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_assets);
            builder.RegisterInstance(_config);
            
            builder.Register<Gameplay.FieldStorage>(Lifetime.Singleton);
            builder.Register<UnitsSpawner>(Lifetime.Singleton);
            builder.Register<IUnitFactory, UnitFactory>(Lifetime.Singleton);
            
            builder.RegisterEntryPoint<GameEntryPoint>();
        }
    }
}
