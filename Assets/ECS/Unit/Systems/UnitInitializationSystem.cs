using Leopotam.Ecs;

namespace Client 
{
    sealed class UnitInitializationSystem : IEcsRunSystem 
    {
        EcsFilter<Unit, INeedInitializationComponent> _filter;
        
        void IEcsRunSystem.Run () {
            
        }
    }
}