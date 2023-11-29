using Leopotam.Ecs;
using UnityEngine;

namespace Zooworld.GameEngine
{
	// TODO: Mock classes
	public class SpawnPrefab
	{
		public MonoEntity Prefab;
	}

	public class MonoEntity : MonoBehaviour
	{
		
	}
	
	public class EnemyFactory
	{
		private readonly EcsWorld _world;
	
		public EnemyFactory(EcsWorld world)
		{
			_world = world;
		}
	
		public void Spawn(SpawnPrefab spawnData)
		{
			var monoEntity = Object.Instantiate(spawnData.Prefab);
			var ecsEntity = _world.NewEntity();
			// monoEntity.Make(ref ecsEntity);
		}
	}
}