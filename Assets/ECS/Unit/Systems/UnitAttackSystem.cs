using Leopotam.Ecs;
using UnityEngine;

namespace Client 
{
    sealed class UnitAttackSystem : IEcsRunSystem 
    {
        EcsFilter<Unit, Attackable, IsAttackingComponent, HealthComponent> _filter;

        void IEcsRunSystem.Run ()
        {
            foreach(var i in _filter)
            {
                ref var attackable = ref _filter.Get2(i);

                if (attackable.Timer > 0)
                {
                    attackable.Timer -= Time.deltaTime;
                }

                if (_filter.Get3(i).IsAttacking)
                {
                    if (attackable.Timer <= 0)
                    {
                        ref var targetHealth = ref attackable.Target.gameObject.GetComponent<CollisionChecker>().
                            entity.Get<HealthComponent>();
                        ref var unitHealth = ref _filter.Get4(i);

                        targetHealth.HP -= attackable.Damage;
                        unitHealth.HP += attackable.Damage;

                        attackable.Timer = attackable.AttackTime;
                    }
                }
            }    
        }
    }
}