using Leopotam.Ecs;

namespace Client {
    sealed class EcsRunSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        private EcsFilter<EcsComponent> _filter;
        
        void IEcsRunSystem.Run () {
            
        }
    }
}