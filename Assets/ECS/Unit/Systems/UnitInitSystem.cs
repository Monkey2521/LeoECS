using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class UnitInitSystem : IEcsInitSystem {
        
        readonly EcsWorld _world = null;

        UnitSpawningData _spawnData;
        UnitStatsData _statsData;
        SceneData _sceneData;

        public void Init () {
            for (int index = 0; index < _spawnData.TeamCount; index++)
            {
                Transform currentTeamParent = Object.Instantiate
                    (
                        new GameObject(_spawnData.SpawningData[index].team.ToString() + " team"), 
                        _sceneData.UnitParent
                    ).transform;

                for (int i = 0; i < _spawnData.MaxUnitsInTeam; i++)
                {
                    EcsEntity unitEntity = _world.NewEntity();

                    ref var unit = ref unitEntity.Get<Unit>();
                    ref var unitHealth = ref unitEntity.Get<Health>();
                    ref var unitBounceable = ref unitEntity.Get<Bounceable>();
                    ref var unitMoveable = ref unitEntity.Get<Moveable>();
                    ref var unitScale = ref unitEntity.Get<Scale>();

                    GameObject unitGO = Object.Instantiate
                        (
                            _spawnData.UnitPrefab,
                            GetNearbyPosition(_spawnData.SpawningData[index].SpawnPoint),
                            Quaternion.identity,
                            currentTeamParent
                        );

                    unitGO.GetComponent<CollisionChecker>().ecsWorld = _world;

                    unit.transform = unitGO.transform;
                    unit.team = _spawnData.SpawningData[index].team;
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

                    unitHealth.HP = _statsData.HealthPoints;
                    unitHealth.MaxHP = _statsData.MaxHealthPoints;

                    unitBounceable.rigidbody = unitGO.GetComponent<Rigidbody>();
                    unitBounceable.force = _statsData.BounceForce;

                    unitMoveable.speed = _statsData.Speed;

                    unitScale.SetTransform(unit.transform);
                }
            }
        }

        private Vector3 GetNearbyPosition(Vector3 position)
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