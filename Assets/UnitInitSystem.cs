using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class UnitInitSystem : IEcsInitSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private StaticData staticData;
        
        public void Init () {
            EcsEntity unitEntity = _world.NewEntity();

            ref var unit = ref unitEntity.Get<Unit>();

            GameObject unitGO = Object.Instantiate(staticData.UnitPrefab);

            unit.UnitTransform = unitGO.transform;
        }
    }
}