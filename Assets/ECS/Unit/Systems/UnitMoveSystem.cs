using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class UnitMoveSystem : IEcsRunSystem
    {
        EcsFilter<Unit, Moveable> _filter;

        SceneData data;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var unit = ref _filter.Get1(i);
                ref var unitMoveable = ref _filter.Get2(i);

                ref var entity = ref _filter.GetEntity(i);

                Vector3 direction = unit.transform.TransformDirection(Vector3.forward) * unitMoveable.speed;

                unit.transform.position += direction * Time.fixedDeltaTime;
            }
        }
    }
}