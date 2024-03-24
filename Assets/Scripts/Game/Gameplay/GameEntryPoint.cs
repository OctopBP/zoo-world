using System.Threading;
using Cysharp.Threading.Tasks;
using VContainer;
using VContainer.Unity;
using ZooWorld.Core;
using ZooWorld.Game.Units;

namespace ZooWorld.Game.Gameplay
{
    public class GameEntryPoint : IAsyncStartable, ITickable
    {
        [Inject] private ILog _log;
        [Inject] private UnitsSpawner _unitsSpawner;
        [Inject] private DeadUnitsUI _deadUnitsUI;
        [Inject] private UnitFactory _unitFactory;
        
        public async UniTask StartAsync(CancellationToken cancellation)
        {
            await _unitFactory.StartAsync(cancellation);
            _deadUnitsUI.Start();
            _unitsSpawner.Start();
            
            _log.Log("GameEntryPoint Started");
        }

        public void Tick()
        {
            _unitsSpawner.Tick();
        }
    }
}