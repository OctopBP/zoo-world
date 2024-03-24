using UnityEngine;
using VContainer;
using VContainer.Unity;
using ZooWorld.Core;
using ZooWorld.Game.Units;
using ZooWorld.Game.Units.Types;

namespace ZooWorld.Game.Gameplay
{
    public class UnitsSpawner : IStartable, ITickable
    {
        [Inject] private ILog _log;
        [Inject] private IRnd _rnd;
        [Inject] private Data.Config _config;
        [Inject] private UnitFactory _unitFactory;
        [Inject] private UnitsSpawnerView _unitsSpawnerView;

        private float _delay = float.PositiveInfinity;
        
        public void Start()
        {
            _delay = 0;
        }
        
        public void Tick()
        {
            _delay -= Time.deltaTime;
            
            if (_delay > 0)
            {
                return;
            }
            
            SpawnUnit();
            SetRandomDelay();
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

        private void SpawnUnit()
        {
            var randomType = _rnd.RandomBool() ? UnitType.Frog : UnitType.Snake;
            var newUnit = _unitFactory.Get(randomType);
            newUnit.transform.position = RandomSpawnPosition();
            newUnit.transform.rotation = Quaternion.Euler(0, _rnd.RandomRange(0, 360), 0);
            
            _log.Log($"Spawn {randomType}");
        }
    }
}