using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class UnitMoveSystem : IEcsRunSystem
    {
        EcsFilter<Unit, Moveable, TransformComponent, IsCompressingComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                if (!_filter.Get4(i).IsCompressing)
                {
                    ref var moveable = ref _filter.Get2(i);
                    ref var transform = ref _filter.Get3(i);

                    Vector3 direction = transform.Transform.TransformDirection(Vector3.forward) * moveable.speed;

                    transform.Position += direction * Time.fixedDeltaTime;
                }
            }
        }
    }
}