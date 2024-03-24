using System;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using ZooWorld.Game.Gameplay;
using ZooWorld.Game.Units.Scope;
using ZooWorld.Game.Units.Views;
using ZooWorld.Game.Utils;

namespace ZooWorld.Game.Units.Collisions
{
    public class UnitCollisionResolver : IStartable, ILateTickable, IDisposable
    {
        [Inject] private UnitView _unitView;
        [Inject] private FoodChainResolver _foodChainResolver;
        [Inject] private FoodChainBehaviour _foodChainBehaviour;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        
        public void Start()
        {
            _unitView.OnCollisionEnterSubj
                .Subscribe(OnHit)
                .AddTo(_disposable);
        }

        private void OnHit(Collision other)
        {
            if (other.gameObject.TryGetComponent<UnitScope>(out var otherUnit))
            {
                OnUnitHit(otherUnit);
            }
            else if (other.gameObject.CompareTag(Tags.Wall))
            {
                OnWallHit(other);
            }
        }
        
        private void OnUnitHit(UnitScope otherUnit)
        {
            var otherBehaviour = otherUnit.Container.Resolve<FoodChainBehaviour>();
            var (firstResult, secondResult) = _foodChainResolver.ResolveCollision(_foodChainBehaviour, otherBehaviour);
            
            _foodChainBehaviour.OnCollisionResolved(firstResult);
            otherBehaviour.OnCollisionResolved(secondResult);
        }
        
        private void OnWallHit(Collision collision)
        {
            if (collision.contactCount < 0)
            {
                throw new Exception("No contact points on OnCollisionEnter");
            }

            var contactNormal = collision.contacts[0].normal;
            _unitView.transform.forward = Vector3.Reflect(_unitView.transform.forward, contactNormal);
        }

        public void LateTick()
        {
            _foodChainBehaviour.Release();
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}