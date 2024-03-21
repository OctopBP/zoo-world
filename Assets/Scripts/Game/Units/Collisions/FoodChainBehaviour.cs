using ZooWorld.Game.Gameplay;

namespace ZooWorld.Game.Units.Collisions
{
    public abstract class FoodChainBehaviour
    {
        public abstract bool CanEatOther { get; }
        protected bool Resolved;

        public virtual void OnCollisionResolved(FoodChainResolver.CollisionResult result)
        {
            Resolved = true;
        }

        public virtual void Release()
        {
            Resolved = false;
        }
    }
}