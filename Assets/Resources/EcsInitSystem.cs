using Leopotam.Ecs;

namespace Client {
    sealed class EcsInitSystem : IEcsInitSystem {
        readonly EcsWorld _world = null;
        
        public void Init () {
            EcsEntity testEntity = _world.NewEntity();

            ref var entity = ref testEntity.Get<EcsComponent>();

        }
    }
}