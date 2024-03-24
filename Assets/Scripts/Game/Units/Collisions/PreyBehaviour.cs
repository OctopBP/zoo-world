using System;
using VContainer;
using ZooWorld.Game.Gameplay;
using ZooWorld.Game.Units.Views;

namespace ZooWorld.Game.Units.Collisions
{
    public class PreyBehaviour : FoodChainBehaviour
    {
        [Inject] private DeadUnitsUI _deadUnitsUI;
        [Inject] private UnitView _unitView;
        [Inject] private PoolContainer _poolContainer;
        
        public override bool CanEatOther => false;
        
        public override void OnCollisionResolved(FoodChainResolver.CollisionResult result)
        {
            if (Resolved) return;
            Resolved = true;

            switch (result)
            {
                case FoodChainResolver.CollisionResult.Eaten:
                    _poolContainer.Release();
                    _deadUnitsUI.IncreaseDeadPreys();
                    break;

                case FoodChainResolver.CollisionResult.Nothing:
                case FoodChainResolver.CollisionResult.Ate:
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(result), result, null);
            }
        }
    }
}