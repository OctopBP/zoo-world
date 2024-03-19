using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using ZooWorld.Core;

namespace ZooWorld.Game.Units
{
    public class UnitFactory : IUnitFactory
    {
        [Inject] private Data.Assets _assets;
        [Inject] private IRnd _rnd;
        [Inject] private IAssetProvider _assetProvider;
        [Inject] private IObjectResolver _container;
        [Inject] private LifetimeScope _currentScope;

        private readonly Dictionary<UnitType, IInstaller> _installersByUnitTypeMap = 
            new Dictionary<UnitType, IInstaller>
        {
            { UnitType.Frog, new FrogInstaller() },
            { UnitType.Snake, new SnakeInstaller() },
        };
        
        public async UniTask<GameObject> Create(UnitType type)
        {
            var assetReference = _assets.UnitModels.Get(type);
            var asset = await _assetProvider.LoadAssetAsync<GameObject>(assetReference);

            var instance = _container.Instantiate(asset, Vector3.zero, Quaternion.Euler(0, _rnd.RandomRange(0, 360), 0));
            
            _currentScope.CreateChild(builder =>
            {
                builder.RegisterInstance(new UnitView(instance));
                builder.RegisterEntryPoint<UnitInit>(Lifetime.Scoped);
                
                var installer = _installersByUnitTypeMap[type];
                installer.Install(builder);
            });
            
            return instance;
        }
    }
}