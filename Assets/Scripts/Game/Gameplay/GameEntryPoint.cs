using VContainer;
using VContainer.Unity;
using ZooWorld.Core;

namespace ZooWorld.Game.Gameplay
{
    public class GameEntryPoint : IStartable, ITickable
    {
        [Inject] private ILog _log;
        [Inject] private UnitsSpawner _unitsSpawner;
        [Inject] private DeadUnitsUI _deadUnitsUI;
        
        public void Start()
        {
            _log.Log("GameEntryPoint Start");
            _deadUnitsUI.Start();
        }

        public void Tick()
        {
            _unitsSpawner.Tick();
        }
    }
}