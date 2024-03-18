using VContainer;
using VContainer.Unity;
using ZooWorld.Core;

namespace ZooWorld.Game
{
    public class GamePresenter : ITickable
    {
        [Inject] private ILog _log; 
        
        public void Tick()
        {
            _log.Log("Update");
        }
    }
}