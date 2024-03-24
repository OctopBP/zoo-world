using UnityEngine;
using VContainer;
using VContainer.Unity;
using ZooWorld.Game.Gameplay;
using ZooWorld.Game.Units;

namespace ZooWorld.Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [Header("Data")]
        [SerializeField] private Data.Assets _assets;
        [SerializeField] private Data.Config _config;
        
        [Header("Views")]
        [SerializeField] private UnitsSpawnerView _unitsSpawnerView;
        
        [Header("UI")]
        [SerializeField] private GameUI _gameUI;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_assets);
            builder.RegisterInstance(_config);
            builder.RegisterInstance(_unitsSpawnerView);
            builder.RegisterInstance(_gameUI);
            
            builder.Register<UnitsSpawner>(Lifetime.Singleton);
            builder.Register<DeadUnitsUI>(Lifetime.Singleton);
            builder.Register<FoodChainResolver>(Lifetime.Singleton);
            builder.Register<UnitFactory>(Lifetime.Singleton);
            
            builder.RegisterEntryPoint<GameEntryPoint>();
        }
    }
}
