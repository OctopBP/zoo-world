using VContainer;
using ZooWorld.Game.Units.Views;

namespace ZooWorld.Game.Units.Movement
{
    public class СrawlMovement : IMovable
    {
        [Inject] private UnitView _unitView;
        [Inject] private Data.Config _config;
        
        public void Move(float deltaTime)
        {
            var transform = _unitView.transform;
            transform.position += _config.CrowMovementConfig.Speed * deltaTime * transform.forward;
        }
    }
}