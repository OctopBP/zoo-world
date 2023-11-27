namespace Zooworld.GameEngine
{
	public class EnemyFactory
	{
		private readonly EcsWorld _world;
	
		public EnemyFactory(EcsWorld world)
		{
			_world = world;
		}
	
		public void Spawn(SpawnPrefab spawnData)
		{
			var gameObject = Instantiate(spawnData.Prefab, spawnData.Position, spawnData.Rotation, spawnData.Parent);
			var monoEntity = gameObject.GetComponent<MonoEntity>();
			
			if (monoEntity == null) 
				return;
			
			var ecsEntity = _world.NewEntity();
			monoEntity.Make(ref ecsEntity);
		}
	}
}