using VContainer;
using ZooWorld.Core;
using ZooWorld.Game.Units.Collisions;

namespace ZooWorld.Game.Gameplay
{
    public class FoodChainResolver
    {
        [Inject] private IRnd _rnd;
        
        public enum CollisionResult
        {
            Eaten,
            Nothing,
            Ate,
        } 
        
        public (CollisionResult, CollisionResult) ResolveCollision(FoodChainBehaviour right, FoodChainBehaviour left)
        {
            if (right.CanEatOther && left.CanEatOther)
            {
                return right.GetHashCode() > left.GetHashCode() == _rnd.RandomBool()
                    ? (CollisionResult.Ate, CollisionResult.Eaten)
                    : (CollisionResult.Eaten, CollisionResult.Ate);
            }
            
            if (right.CanEatOther)
            {
                return (CollisionResult.Ate, CollisionResult.Eaten);
            }
            
            if (left.CanEatOther)
            {
                return (CollisionResult.Eaten, CollisionResult.Ate);
            }

            return (CollisionResult.Nothing, CollisionResult.Nothing);
        }
    }
}