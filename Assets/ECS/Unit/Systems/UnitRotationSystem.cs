using Leopotam.Ecs;
using UnityEngine;

namespace Client 
{
    sealed class UnitRotationSystem : IEcsRunSystem 
    {
        EcsFilter<Unit, Attackable, TransformComponent> _filter;

        void IEcsRunSystem.Run () 
        {
            foreach (var i in _filter)
            {
                ref var attackable = ref _filter.Get2(i);

                if (attackable.Target != null)
                {
                    ref var transform = ref _filter.Get3(i);

                    Vector3 targetPos = new Vector3
                        (
                            attackable.Target.position.x,
                            transform.Position.y,
                            attackable.Target.position.z
                        );

                    transform.Transform.LookAt(targetPos);
                }
            }
        }
    }
}