using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class UnitMoveSystem : IEcsSystem
    {
        private EcsFilter<Unit> filter;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var unit = ref filter.Get1(i);

                Vector3 direction = new Vector3(
                    unit.UnitTransform.position.x * unit.Velocity.x
                    , unit.UnitTransform.position.y * unit.Velocity.y
                    , unit.UnitTransform.position.z * unit.Velocity.z)
                    .normalized;

                unit.UnitTransform.position += direction * Time.fixedDeltaTime;
            }
        }
    }
}