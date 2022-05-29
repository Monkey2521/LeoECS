using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class UnitInitSystem : IEcsInitSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private StaticData staticData;
        private SceneData sceneData;
        
        public void Init () {
            EcsEntity unitEntity = _world.NewEntity();

            ref var unit = ref unitEntity.Get<Unit>();

            GameObject unitGO = Object.Instantiate(staticData.UnitPrefab);

            unit.UnitTransform = unitGO.transform;
            unit.Velocity = Vector3.right;

            sceneData.UnitPosition = unitGO.transform;
        }
    }
}