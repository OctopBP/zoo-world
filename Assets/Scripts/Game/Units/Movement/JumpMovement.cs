using VContainer;

namespace ZooWorld.Game.Units.Movement
{
    public class JumpMovement : IMovable
    {
        [Inject] private UnitView _unitView;
        [Inject] private Data.Config _config;

        private float _time;
        
        public void Move(float deltaTime)
        {
            _time += deltaTime;
            var value = _config.JumpMovement.MovementCurve.Evaluate(_time % 1);
            var transform = _unitView.GameObject.transform;
            transform.position += transform.forward * value * deltaTime * _config.JumpMovement.Speed;
        }
    }
}
