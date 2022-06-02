using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class UnitMoveSystem : IEcsRunSystem
    {
        EcsFilter<Unit, Moveable> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var unitMoveable = ref _filter.Get2(i);

                ref var entity = ref _filter.GetEntity(i);

                Vector3 direction = unitMoveable.transform.TransformDirection(Vector3.forward) * unitMoveable.speed;

                unitMoveable.Position += direction * Time.fixedDeltaTime;
            }
        }
    }
}