using Leopotam.Ecs;
using UnityEngine;

namespace Client 
{
    sealed class EcsStartup : MonoBehaviour 
    {
        EcsWorld _world;

        EcsSystems _updateSystems;
        EcsSystems _fixedUpdateSystems;

        [Header("Unit settings")]
        [SerializeField] UnitSpawningData unitSpawningData;
        [SerializeField] UnitStatsData unitStatsData;

        [Header("Settings")]
        [SerializeField] SceneData sceneData;

        void Start () {          
            _world = new EcsWorld ();
            _updateSystems = new EcsSystems (_world);
            _fixedUpdateSystems = new EcsSystems(_world);

            #if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_updateSystems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_fixedUpdateSystems);
            #endif

            _updateSystems
                        .Add(new UnitStartSystem())
                        .Add(new UnitCloneSystem())
                        .Add(new UnitInitializationSystem())
                        .Add(new UnitNavigationSystem())
                        .Add(new UnitAttackCheckSystem())
                        .Add(new UnitAttackSystem())
                        .Add(new HealthScalerSystem())
                        .Add(new UnitDestroySystem())
                        //.Add(new TestHealthSystem())
                        .OneFrame<CollisionComponent>()
                        .OneFrame<INeedInitializationFlag>()
                        .OneFrame<IDestroyFlag>()
                        .Inject(unitSpawningData)
                        .Inject(unitStatsData)
                        .Inject(sceneData);

            _fixedUpdateSystems
                .Add(new IsGroundedCheckSystem())
                .Add(new UnitCompressionSystem())
                .Add(new CompressionSystem())
                .Add(new UnitRotationSystem())
                .Add(new BounceSystem())
                .Add(new UnitMoveSystem())
                .Inject(sceneData)
                .Inject(unitStatsData);

            _updateSystems.Init();
            _fixedUpdateSystems.Init();
        }

        void Update () {
            _updateSystems?.Run ();
        }

        void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
        }

        void OnDestroy () {
            if (_updateSystems != null) {
                _updateSystems.Destroy ();
                _updateSystems = null;
            }

            if (_fixedUpdateSystems != null)
            {
                _fixedUpdateSystems.Destroy();
                _fixedUpdateSystems = null;
            }

            _world.Destroy();
            _world = null;
        }
    }
}