using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using ZooWorld.Core;
using ZooWorld.Game.Units.Scope;
using ZooWorld.Game.Units.Types;

namespace ZooWorld.Game.Units
{
    public class UnitFactory : IUnitFactory
    {
        [Inject] private Data.Assets _assets;
        [Inject] private IRnd _rnd;
        [Inject] private IAssetProvider _assetProvider;
        [Inject] private IObjectResolver _container;
        [Inject] private LifetimeScope _currentScope;

        private readonly UnitTypeForIInstaller _unitTypeForIInstaller =
            new UnitTypeForIInstaller(frog: new FrogInstaller(), snake: new SnakeInstaller());
        
        public async UniTask<GameObject> Create(UnitType type)
        {
            var assetReference = _assets.UnitModels.Get(type);
            var asset = await _assetProvider.LoadAssetAsync<GameObject>(assetReference);
            var scopePrefab = asset.GetComponent<UnitScope>();
            
            var installer = _unitTypeForIInstaller.Get(type);
            var instance = _currentScope.CreateChildFromPrefab(scopePrefab, installer);
            
            return instance.gameObject;
        }
    }
}