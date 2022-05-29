using Leopotam.Ecs;

namespace Client {
    sealed class UnitInitSystem : IEcsInitSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        
        public void Init () {
            EcsEntity unitEntity = _world.NewEntity();

            ref var unit = ref unitEntity.Get<Unit>();
        }
    }
}