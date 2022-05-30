using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class UnitMoveSystem : IEcsRunSystem
    {
        EcsFilter<Unit> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var unit = ref _filter.Get1(i);

                Vector3 direction = unit.transform.TransformDirection(Vector3.forward) * unit.speed;

                unit.transform.position += direction * Time.fixedDeltaTime;
            }
        }
    }
}