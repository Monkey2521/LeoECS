using Leopotam.Ecs;
using UnityEngine;

namespace Client 
{
    sealed class UnitDestroySystem : IEcsRunSystem 
    {    
        EcsFilter<Unit, IDestroyFlag> _filter;

        void IEcsRunSystem.Run () 
        {
            foreach (var i in _filter)
            {
                ref var unit = ref _filter.Get1(i);

                Object.Destroy(unit.gameObject);

                _filter.GetEntity(i).Destroy();
            }    
        }
    }
}