using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class UnitMoveSystem : IEcsSystem, IEcsRunSystem
    {
        private EcsFilter<Unit> filter;
        private SceneData sceneData;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var unit = ref filter.Get1(i);

                Vector3 direction = (unit.UnitTransform.position + unit.Velocity).normalized;

                unit.UnitTransform.position += direction * Time.fixedDeltaTime;
            }
        }
    }
}