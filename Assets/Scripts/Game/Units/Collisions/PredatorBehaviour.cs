using System;
using Cysharp.Threading.Tasks;
using VContainer;
using ZooWorld.Game.Gameplay;
using ZooWorld.Game.Units.Views;

namespace ZooWorld.Game.Units.Collisions
{
    public class PredatorBehaviour : FoodChainBehaviour
    {
        [Inject] private DeadUnitsUI _deadUnitsUI;
        [Inject] private UnitView _unitView;
        [Inject] private PredatorView _predatorView;
        [Inject] private PredatorViewController _predatorViewController;
        
        public override bool CanEatOther => true;

        public override void OnCollisionResolved(FoodChainResolver.CollisionResult result)
        {
            if (Resolved) return;
            Resolved = true;

            base.OnCollisionResolved(result);
            switch (result)
            {
                case FoodChainResolver.CollisionResult.Eaten:
                    _unitView.Destroy();
                    _deadUnitsUI.IncreaseDeadPredators();
                    break;
                
                case FoodChainResolver.CollisionResult.Ate:
                    _predatorViewController.ShowText().Forget();
                    break;
                
                case FoodChainResolver.CollisionResult.Nothing: break;
                default: throw new ArgumentOutOfRangeException(nameof(result), result, null);
            }
        }
    }
}