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
                    ref var unitTransform = ref unitEntity.Get<TransformComponent>();
                    ref var unitInit = ref unitEntity.Get<INeedInitializationComponent>();

                    GameObject unitGO = Object.Instantiate
                    (
                        _spawnData.UnitPrefab,
                        GetNearbyPosition(_spawnData.SpawningData[index].SpawnPoint),
                        Quaternion.identity,
                        currentTeamParent
                    );

                    unitGO.GetComponent<CollisionChecker>().entity = unitEntity;

                    unit.team = _spawnData.SpawningData[index].Team;
                    unit.material = unitGO.GetComponent<MeshRenderer>().material;
                    unit.gameObject = unitGO;

                    unitTransform.Transform = unitGO.transform;
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