using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class UnitCloneSystem : IEcsRunSystem 
    {
        readonly EcsWorld _world = null;

        EcsFilter<Unit, HealthComponent> _filter;

        UnitSpawningData _spawnData;

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
                    ref var unitInit = ref unitEntity.Get<INeedInitializationFlag>();

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

                    unitTransform.Transform = unitGO.transform;
                }
            }
        }
    }
}