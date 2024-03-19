using VContainer;
using VContainer.Unity;
using ZooWorld.Core;

namespace ZooWorld.Game.Gameplay
{
    public class GameEntryPoint : IStartable, ITickable
    {
        [Inject] private ILog _log;
        [Inject] private UnitsSpawner _unitsSpawner;
        
        public void Start()
        {
            _log.Log("GameEntryPoint Start");
            _unitsSpawner.Start();
        }

        public void Tick()
        {
            _unitsSpawner.Tick();
        }
    }
}