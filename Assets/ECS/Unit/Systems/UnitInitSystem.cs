using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class UnitInitSystem : IEcsInitSystem {
        
        readonly EcsWorld _world = null;

        UnitSpawningData _spawnData;
        UnitStatsData _statsData;

        public void Init () {

            for (int index = 0; index < _spawnData.TeamCount; index++)
            {
                for (int i = 0; i < _spawnData.MaxUnitsInTeam; i++)
                {
                    EcsEntity unitEntity = _world.NewEntity();

                    ref var unit = ref unitEntity.Get<Unit>();
                    ref var unitHealth = ref unitEntity.Get<Health>();

                    GameObject unitGO = Object.Instantiate
                        (
                            _spawnData.UnitPrefab, 
                            GetNearbyPosition(_spawnData.SpawningData[index].SpawnPoint), 
                            Quaternion.identity
                        );

                    unit.transform = unitGO.transform;
                    unit.speed = _statsData.Speed;

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