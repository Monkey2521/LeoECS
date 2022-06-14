using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class UnitCloneSystem : IEcsRunSystem 
    {
        readonly EcsWorld _world = null;

        EcsFilter<Unit, HealthComponent> _filter;

        UnitSpawningData _spawnData;
        UnitStatsData _statsData;

        void IEcsRunSystem.Run () {
            foreach(var i in _filter)
            {
                ref var unit = ref _filter.Get1(i);
                ref var health = ref _filter.Get2(i);

                if (health.HP * 0.5f >= health.MaxHP)
                {
                    health.HP = health.MaxHP;

                    EcsEntity unitEntity = _world.NewEntity();

                    ref var newUnit = ref unitEntity.Get<Unit>();
                    ref var unitTransform = ref unitEntity.Get<TransformComponent>();
                    ref var unitHealth = ref unitEntity.Get<HealthComponent>();
                    ref var unitGrounded = ref unitEntity.Get<IsGroundedComponent>();
                    ref var unitBounceable = ref unitEntity.Get<Bounceable>();
                    ref var unitMoveable = ref unitEntity.Get<Moveable>();
                    ref var unitAttackable = ref unitEntity.Get<Attackable>();
                    ref var unitIsAttacking = ref unitEntity.Get<IsAttackingComponent>();
                    ref var unitCompression = ref unitEntity.Get<IsCompressingComponent>();
                    ref var unitCompressionChecker = ref unitEntity.Get<CompressionCheckerComponent>();

                    GameObject unitGO = Object.Instantiate
                        (
                            _spawnData.UnitPrefab,
                            unit.gameObject.transform.position,
                            Quaternion.identity,
                            unit.gameObject.transform.parent
                        );

                    unitGO.GetComponent<CollisionChecker>().entity = unitEntity;

                    newUnit.team = unit.team;
                    newUnit.material = unitGO.GetComponent<MeshRenderer>().material;
                    newUnit.gameObject = unitGO;

                    switch (newUnit.team)
                    {
                        case Teams.Red:
                            newUnit.material.color = Color.red;
                            break;
                        case Teams.Blue:
                            newUnit.material.color = Color.blue;
                            break;
                        case Teams.Green:
                            newUnit.material.color = Color.green;
                            break;
                        case Teams.Yellow:
                            newUnit.material.color = Color.yellow;
                            break;
                        default:
                            Debug.Log("Something is going wrong");
                            break;
                    }

                    unitTransform.Transform = unitGO.transform;

                    unitHealth.HP = _statsData.HP;
                    unitHealth.MaxHP = _statsData.MaxHP;

                    unitBounceable.rigidbody = unitGO.GetComponent<Rigidbody>();
                    unitBounceable.force = _statsData.BounceForce;

                    unitMoveable.speed = _statsData.Speed;

                    unitAttackable.Target = null;
                    unitAttackable.Damage = _statsData.Damage;
                    unitAttackable.AttackTime = _statsData.AttackTime;
                    unitIsAttacking.IsAttacking = false;

                    unitCompression.Timer = 0;
                    unitCompression.IsCompressing = false;

                    unitCompressionChecker.CurrentGrounded = true;
                    unitCompressionChecker.PreviousGrounded = true;
                }
            }
        }
    }
}