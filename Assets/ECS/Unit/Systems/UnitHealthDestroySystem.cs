using Leopotam.Ecs;
using UnityEngine;

namespace Client 
{
    sealed class UnitHealthDestroySystem : IEcsRunSystem 
    {    
        EcsFilter<Unit, HealthComponent> _filter;

        void IEcsRunSystem.Run () 
        {
            foreach (var i in _filter)
            {
                ref var unit = ref _filter.Get1(i);
                ref var health = ref _filter.Get2(i);

                if (health.HP <= 0)
                {
                    Object.Destroy(unit.gameObject);

                    _filter.GetEntity(i).Destroy();
                }
            }    
        }
    }
}