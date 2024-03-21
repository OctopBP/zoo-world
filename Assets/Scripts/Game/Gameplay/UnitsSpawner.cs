using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using ZooWorld.Core;
using ZooWorld.Game.Units;
using ZooWorld.Game.Units.Types;

namespace ZooWorld.Game.Gameplay
{
    public class UnitsSpawner : ITickable
    {
        [Inject] private ILog _log;
        [Inject] private IRnd _rnd;
        [Inject] private Data.Config _config;
        [Inject] private Data.Assets _assets;
        [Inject] private IAssetProvider _assetProvider;
        [Inject] private IUnitFactory _unitFactory;
        [Inject] private UnitsSpawnerView _unitsSpawnerView;
        
        private float _delay = 0;

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

        private Vector3 RandomSpawnPosition()
        {
            var randomIndex = _rnd.RandomRange(0, _unitsSpawnerView.SpawnPoints.Length);
            return _unitsSpawnerView.SpawnPoints[randomIndex].position;
        }

        private void SetRandomDelay()
        {
            _delay = _rnd.RandomRange(_config.SpawnRange.x, _config.SpawnRange.y);
        }

        private async UniTask SpawnUnit()
        {
            var newUnit = await _unitFactory.Create(_rnd.RandomBool() ? UnitType.Frog : UnitType.Snake);
            newUnit.transform.position = RandomSpawnPosition();
            newUnit.transform.rotation = Quaternion.Euler(0, _rnd.RandomRange(0, 360), 0);
        }
    }
}