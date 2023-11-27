using Leopotam.Ecs;

namespace Zooworld.GameEngine.Systems
{
	public class SetTransformSystem : IEcsRunSystem
	{
		private EcsFilter<TransformComponent> _transformComponentFilter;
		
		public void Run()
		{
			foreach (var entityIndex in _transformComponentFilter)
			{
				ref var transformComponent = ref _transformComponentFilter.Get1(entityIndex);
			}
		}
	}
}