using UnityEngine;
using VContainer;
using VContainer.Unity;
using ZooWorld.Core;
using ZooWorld.Game.Units.Movement;

namespace ZooWorld.Game.Units
{
    public class UnitInit : ITickable
    {
        [Inject] private ILog _log;
        [Inject] private IMovable _movable;

        public void Tick()
        {
            _movable.Move(Time.deltaTime);
        }
    }
}