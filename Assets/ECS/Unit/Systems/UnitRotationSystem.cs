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
                ref var transform = ref _filter.Get3(i);

                if (attackable.Target != null)
                {
                    transform.Transform.LookAt(attackable.Target);
                }
            }
        }
    }
}