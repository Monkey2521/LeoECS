using Leopotam.Ecs;
using UnityEngine;

namespace Client 
{
    sealed class HealthScalerSystem : IEcsRunSystem
    { 
        EcsFilter<Scale, Health> _filter;

        int _i = 0;

        void IEcsRunSystem.Run()
        {
            foreach(var i in _filter)
            {
                ref var scale = ref _filter.Get1(i);
                ref var health = ref _filter.Get2(i);

                if (_i == 9)
                {
                    health.HP += 1;
                }

                float multiplier = health.HP / health.MaxHP;

                if (multiplier > 0)
                    scale.scale = Vector3.one * multiplier;
            }

            _i = _i == 9 ? 0 : ++_i;
        }
    }
}