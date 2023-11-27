using Leopotam.Ecs;
using UnityEngine;

namespace Zooworld.GameEngine.Systems
{
	public class JumpMovementSystem : IEcsRunSystem
	{
		private EcsFilter<JumpsMovementComponent, TransformComponent>.Exclude<JumpBlockTimerComponent> _jumpMovementFilter;
		
		public void Run()
        {
	        foreach (var entityIndex in _jumpMovementFilter)
	        {
		        ref var entity = ref _jumpMovementFilter.GetEntity(entityIndex);
		        
		        ref var jumpsMovementComponent = ref _jumpMovementFilter.Get1(entityIndex);
		        ref var transformComponent = ref _jumpMovementFilter.Get2(entityIndex);

		        transformComponent.Transform.position += Vector3.forward * jumpsMovementComponent.JumpDistance;
		        
		        // Add block for jump
		        ref var jumpBlock = ref entity.Get<JumpBlockTimerComponent>();
		        jumpBlock.Timer = jumpsMovementComponent.TimeBetweenJumps;
	        }
		}
	}
}