using Leopotam.Ecs;
using UnityEngine;

namespace Client 
{
    sealed class HealthScalerSystem : IEcsRunSystem
    { 
        EcsFilter<ScaleComponent, HealthComponent> _filter;

        void IEcsRunSystem.Run()
        {
            foreach(var i in _filter)
            {
                ref var scale = ref _filter.Get1(i);
                ref var health = ref _filter.Get2(i);

                float multiplier = health.HP / health.MaxHP;

                if (multiplier > 0)
                    scale.scale = Vector3.one * multiplier;
            }
        }
    }
}