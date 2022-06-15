using Leopotam.Ecs;
using UnityEngine;

namespace Client 
{
    sealed class UnitInitializationSystem : IEcsRunSystem 
    {
        EcsFilter<Unit, INeedInitializationFlag> _filter;

        UnitStatsData _statsData;

        void IEcsRunSystem.Run () {
            foreach(var i in _filter)
            {
                EcsEntity unitEntity = _filter.GetEntity(i);
                ref var unit = ref _filter.Get1(i);

                ref var unitHealth = ref unitEntity.Get<HealthComponent>();
                ref var unitGrounded = ref unitEntity.Get<IsGroundedComponent>();
                ref var unitBounceable = ref unitEntity.Get<Bounceable>();
                ref var unitMoveable = ref unitEntity.Get<Moveable>();
                ref var unitAttackable = ref unitEntity.Get<Attackable>();
                ref var unitIsAttacking = ref unitEntity.Get<IsAttackingComponent>();
                ref var unitCompression = ref unitEntity.Get<IsCompressingComponent>();
                ref var unitCompressionChecker = ref unitEntity.Get<CompressionCheckerComponent>();

                switch (unit.team)
                {
                    case Teams.Red:
                        unit.material.color = Color.red;
                        break;
                    case Teams.Blue:
                        unit.material.color = Color.blue;
                        break;
                    case Teams.Green:
                        unit.material.color = Color.green;
                        break;
                    case Teams.Yellow:
                        unit.material.color = Color.yellow;
                        break;
                    default:
                        Debug.Log("Something is going wrong");
                        break;
                }

                unitHealth.HP = _statsData.HP;
                unitHealth.MaxHP = _statsData.MaxHP;

                unitBounceable.rigidbody = unit.gameObject.GetComponent<Rigidbody>();
                unitBounceable.force = _statsData.BounceForce;

                unitMoveable.speed = _statsData.Speed;

                unitAttackable.Target = null;
                unitAttackable.Damage = _statsData.Damage;
                unitAttackable.AttackTime = _statsData.AttackTime;
                unitAttackable.Timer = 0f;

                unitIsAttacking.IsAttacking = false;

                unitCompression.Timer = 0;
                unitCompression.IsCompressing = false;

                unitCompressionChecker.CurrentGrounded = true;
                unitCompressionChecker.PreviousGrounded = true;
            }
        }
    }
}