using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using ZooWorld.Core;
using ZooWorld.Game.Units.Movement;

namespace ZooWorld.Game.Units
{
    public class UnitInit : IStartable, ITickable, ILateTickable
    {
        [Inject] private ILog _log;
        [Inject] private IMovable _movable;
        [Inject] private UnitCollisionResolver _unitCollisionResolver;

        public void Start()
        {
            _unitCollisionResolver.Start();
        }
        
        public void Tick()
        {
            _movable.Move(Time.deltaTime);
        }

        public void LateTick()
        {
            _unitCollisionResolver.LateTick();
        }
    }
}