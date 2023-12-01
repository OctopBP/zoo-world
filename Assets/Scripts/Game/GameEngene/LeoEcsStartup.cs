using Leopotam.Ecs;
using Zooworld.GameEngine.Systems;

namespace Zooworld.GameEngine
{
    public class LeoEcsStartup : IEcsStartup
    {
        private readonly EcsWorld _world;
        private readonly EcsSystems _systems;

        public LeoEcsStartup()
        {
            _world = new();
            _systems = new(_world);
            _systems
                .Add(new JumpBlockTimerSystem())
                .Add(new JumpMovementSystem())
                .Init();
        }

        public void Update()
        {
            _systems.Run();
        }

        public void Dispose()
        {
            _systems.Destroy();
            _world.Destroy();
        }
    }
}
