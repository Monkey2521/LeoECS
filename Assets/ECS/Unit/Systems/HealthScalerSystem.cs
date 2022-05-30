using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class HealthScalerSystem : IEcsRunSystem
    { 
        EcsFilter<Unit, Health> _filter;

        void IEcsRunSystem.Run()
        {
            foreach(var i in _filter)
            {
                ref var unit = ref _filter.Get1(i);
                ref var health = ref _filter.Get2(i);

                float multiplier = health.HP / health.MaxHP;

                unit.transform.localScale = Vector3.one * multiplier;
            }
        }
    }
}