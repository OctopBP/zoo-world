using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using ZooWorld.Core;
using ZooWorld.Game.Units;

namespace ZooWorld.Game.Gameplay
{
    public class UnitsSpawner : IStartable, ITickable
    {
        [Inject] private ILog _log;
        [Inject] private IRnd _rnd;
        [Inject] private Data.Config _config;
        [Inject] private Data.Assets _assets;
        [Inject] private IAssetProvider _assetProvider;
        [Inject] private IUnitFactory _unitFactory;
        [Inject] private FieldStorage _fieldStorage;
        
        private float _delay = 0;

        public void Start()
        {
            SetRandomDelay();
        }

        public void Tick()
        {
            _delay -= Time.deltaTime;
            
            if (_delay > 0)
            {
                return;
            }

            SetRandomDelay();
            SpawnUnit().Forget();
        }

        private void SetRandomDelay()
        {
            _delay = _rnd.RandomRange(_config.SpawnRange.x, _config.SpawnRange.y);
        }

        private async UniTask SpawnUnit()
        {
            var newUnit = await _unitFactory.Create(_rnd.RandomBool() ? UnitType.Frog : UnitType.Snake);
            _fieldStorage.Units.Add(newUnit);
        }
    }
}