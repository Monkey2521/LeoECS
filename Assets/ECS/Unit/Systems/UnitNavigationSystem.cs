using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

namespace Client 
{
    sealed class UnitNavigationSystem : IEcsRunSystem 
    {
        EcsFilter<Unit, Attackable, TransformComponent> _filter;
                
        void IEcsRunSystem.Run () 
        {
            Dictionary<Teams, Transform> teamsTargets = new Dictionary<Teams, Transform>();

            foreach(var i in _filter)
            {
                ref var unit = ref _filter.Get1(i);
                ref var attackable = ref _filter.Get2(i);

                if (teamsTargets.TryGetValue(unit.team, out Transform target))
                {
                    attackable.Target = target;
                }
                else
                {
                    attackable.Target = FindTarget(unit.team);

                    if (attackable.Target != null)
                        teamsTargets.Add(unit.team, attackable.Target);
                }
            }
        }

        Transform FindTarget(Teams team)
        {
            Transform target = null;

            foreach(var i in _filter)
            {
                ref var unit = ref _filter.Get1(i);

                if (unit.team == team)
                {
                    continue;
                }

                ref var transform = ref _filter.Get3(i);

                if (transform.transform != null)
                {
                    target = transform.transform;
                    break;
                }
            }

            return target;
        }
    }
}