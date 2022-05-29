using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class UnitInitSystem : IEcsInitSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private StaticData staticData;
        private SceneData sceneData;
        
        public void Init () {

            for(int i = 0; i < staticData.UnitCount; i ++)
            {
                EcsEntity unitEntity = _world.NewEntity();
                ref var unit = ref unitEntity.Get<Unit>();

                int randIntX = Random.Range(-staticData.N, staticData.N);
                int randIntZ = Random.Range(-staticData.N, staticData.N);

                GameObject unitGO = Object.Instantiate(staticData.UnitPrefab, new Vector3(randIntX, 0, randIntZ), Quaternion.identity);

                unit.UnitTransform = unitGO.transform;
                unit.Velocity = Vector3.right;

                sceneData.UnitPosition = unitGO.transform;
            }
        }
    }
}