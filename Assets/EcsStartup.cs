using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class EcsStartup : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _systems;

        public StaticData staticData;
        public SceneData sceneData;
        private EcsSystems _fixedUpdateSystems; // нова€ группа систем

        void Start () {          
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            _fixedUpdateSystems = new EcsSystems(_world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_fixedUpdateSystems);
#endif

            _systems
                        .Add(new UnitInitSystem())
                        .Inject(staticData)
                        .Inject(sceneData);

            _fixedUpdateSystems
                .Add(new UnitMoveSystem()); // добавл€ем систему движени€

            _systems.Init();
            _fixedUpdateSystems.Init();
        }

        void Update () {
            _systems?.Run ();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;

                _fixedUpdateSystems.Destroy();
                _fixedUpdateSystems = null;

                _world.Destroy ();
                _world = null;
            }
        }
    }
}