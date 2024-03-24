using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;
using VContainer.Unity;
using ZooWorld.Core;
using ZooWorld.Core.Helpers;
using ZooWorld.Game.Units.Scope;
using ZooWorld.Game.Units.Types;

namespace ZooWorld.Game.Units
{
    public class UnitFactory : IAsyncStartable, IUnitFactory
    {
        [Inject] private Data.Assets _assets;
        [Inject] private IAssetProvider _assetProvider;
        [Inject] private LifetimeScope _currentScope;

        private const int WarmupPoolSize = 5;

        private readonly UnitTypeForIObjectPool _poolForUnits = new UnitTypeForIObjectPool();
        
        public async UniTask StartAsync(CancellationToken cancellation)
        {
            foreach (var unitType in UnitTypeExt.Values)
            {
                var assetReference = _assets.UnitModels.Get(unitType);
                var asset = await _assetProvider.LoadAssetAsync<GameObject>(assetReference);
            
                var pool = CreatePool(unitType, asset);
                pool.WarmupPool(WarmupPoolSize);
                _poolForUnits.Set(unitType, pool);
            }
            
            return;

            ObjectPool<GameObject> CreatePool(UnitType type, GameObject asset)
            {
                return new ObjectPool<GameObject>
                (
                    createFunc: Create,
                    go => go.SetActive(true),
                    go => go.SetActive(false)
                );
        
                GameObject Create()
                {
                    var scopePrefab = asset.GetComponent<UnitScope>();
                    var instance = _currentScope.CreateChildFromPrefab(scopePrefab);
                    
                    return instance.gameObject;
                }
            }
        }
        
        public GameObject Get(UnitType type)
        {
            return _poolForUnits.Get(type).Get();
        }
        
        public void Release(UnitType type, GameObject gameObject)
        {
            _poolForUnits.Get(type).Release(gameObject);
        }
    }
}