using Leopotam.Ecs;
using UnityEngine;

namespace Zooworld.GameEngine.Systems
{
	public class JumpBlockTimerSystem : IEcsRunSystem
	{
		private EcsFilter<JumpBlockTimerComponent> _jumpBlockTimerFilter;
		
		public void Run()
		{
			foreach (var entityIndex in _jumpBlockTimerFilter)
			{
				ref var entity = ref _jumpBlockTimerFilter.GetEntity(entityIndex);
				ref var jumpBlockTimerComponent = ref _jumpBlockTimerFilter.Get1(entityIndex);

				var deltaTime = Time.deltaTime;
				if (deltaTime > jumpBlockTimerComponent.Timer)
				{
					entity.Del<JumpBlockTimerComponent>();
				}
				else
				{
					jumpBlockTimerComponent.Timer -= deltaTime;
				}
			}
		}
	}
}