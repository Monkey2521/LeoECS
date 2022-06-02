using Leopotam.Ecs;
using UnityEngine;

namespace Client 
{
    sealed class UnitInitSystem : IEcsInitSystem 
    {
        readonly EcsWorld _world = null;

        UnitSpawningData _spawnData;
        UnitStatsData _statsData;

        public void Init() {
            Transform unitsParent = Object.Instantiate(_spawnData.UnitsParent).transform;
            unitsParent.name = "Units";

            for (int index = 0; index < _spawnData.TeamsCount; index++)
            {
                Transform currentTeamParent = Object.Instantiate
                    (
                        _spawnData.TeamParent,
                        unitsParent
                    ).transform;
                currentTeamParent.name = _spawnData.SpawningData[index].Team.ToString() + " team";

                for (int i = 0; i < _spawnData.MaxUnitsInTeam; i++)
                {
                    EcsEntity unitEntity = _world.NewEntity();

                    ref var unit = ref unitEntity.Get<Unit>();
                    ref var unitHealth = ref unitEntity.Get<HealthComponent>();
                    ref var unitScale = ref unitEntity.Get<ScaleComponent>();
                    ref var unitGrounded = ref unitEntity.Get<IsGroundedComponent>();
                    ref var unitBounceable = ref unitEntity.Get<Bounceable>();
                    ref var unitMoveable = ref unitEntity.Get<Moveable>();

                    GameObject unitGO = Object.Instantiate
                        (
                            _spawnData.UnitPrefab,
                            GetNearbyPosition(_spawnData.SpawningData[index].SpawnPoint),
                            Quaternion.identity,
                            currentTeamParent
                        );

                    unitGO.GetComponent<CollisionChecker>().ecsWorld = _world;

                    unit.team = _spawnData.SpawningData[index].Team;
                    unit.material = unitGO.GetComponent<MeshRenderer>().material;

                    switch (index) 
                    {
                        case (int)Teams.Red:
                            unit.material.color = Color.red;
                            break;
                        case (int)Teams.Blue:
                            unit.material.color = Color.blue;
                            break;
                        case (int)Teams.Green:
                            unit.material.color = Color.green;
                            break;
                        case (int)Teams.Yellow:
                            unit.material.color = Color.yellow;
                            break;
                        default:
                            Debug.Log("Something is going wrong");
                            break;
                    }

                    unitHealth.HP = _statsData.HP;
                    unitHealth.MaxHP = _statsData.MaxHP;

                    unitBounceable.rigidbody = unitGO.GetComponent<Rigidbody>();
                    unitBounceable.force = _statsData.BounceForce;

                    unitMoveable.speed = _statsData.Speed;
                    unitMoveable.SetTransform(unitGO.transform);

                    unitScale.SetTransform(unitGO.transform);

                    unitGrounded.SetTransform(unitGO.transform);
                }
            }
        }

        Vector3 GetNearbyPosition(Vector3 position)
        {
            return position + new Vector3
                (
                    Random.Range(-_spawnData.SpawnSpreading, _spawnData.SpawnSpreading),
                    0f,
                    Random.Range(-_spawnData.SpawnSpreading, _spawnData.SpawnSpreading)
                );
        }
    }
}