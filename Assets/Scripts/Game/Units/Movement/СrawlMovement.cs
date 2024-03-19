using VContainer;
using ZooWorld.Core;

namespace ZooWorld.Game.Units.Movement
{
    public class СrawlMovement : IMovable
    {
        [Inject] private UnitView _unitView;
        [Inject] private IRnd _rnd;
        
        public void Move(float deltaTime)
        {
            var transform = _unitView.GameObject.transform;
            transform.position += (transform.forward + transform.right * _rnd.RandomRange(-1f, 1f)) * deltaTime;
        }
    }
}