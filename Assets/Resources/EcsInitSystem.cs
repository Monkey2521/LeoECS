using Leopotam.Ecs;

namespace Client {
    sealed class EcsInitSystem : IEcsInitSystem
    {
        readonly EcsWorld _world = null;
        
        private EcsFilter<EcsComponent> _filter;

        void IEcsInitSystem.Init()
        {

        }

    }
}