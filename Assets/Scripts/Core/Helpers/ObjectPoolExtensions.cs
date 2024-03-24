using UnityEngine.Pool;

namespace ZooWorld.Core.Helpers
{
    public static class ObjectPoolExtensions
    {
        public static void WarmupPool<T>(this IObjectPool<T> pool, int amount) where T : class
        {
            var items = new T[amount];
            for (var i = 0; i < amount; i++)
            {
                items[i] = pool.Get();
            }
            
            for (var i = 0; i < amount; i++)
            {
                pool.Release(items[i]);
            }
        }
    }
}