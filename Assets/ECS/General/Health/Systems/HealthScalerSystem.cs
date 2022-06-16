using Leopotam.Ecs;
using UnityEngine;

namespace Client 
{
    sealed class HealthScalerSystem : IEcsRunSystem
    {
        EcsWorld _world;

        EcsFilter<TransformComponent, HealthComponent, IsCompressingComponent> _filter;

        void IEcsRunSystem.Run()
        {
            foreach(var i in _filter)
            {
                if (!_filter.Get3(i).IsCompressing)
                {
                    ref var scale = ref _filter.Get1(i);
                    ref var health = ref _filter.Get2(i);

                    float multiplier = health.HP / health.MaxHP;

                    if (multiplier > 0)
                        scale.scale = Vector3.one * multiplier;
                    else
                        _filter.GetEntity(i).Get<IDestroyFlag>();
                }
            }
        }
    }
}