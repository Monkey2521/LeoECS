using Leopotam.Ecs;
using UnityEngine;

namespace Client 
{
    sealed class UnitAttackCheckSystem : IEcsRunSystem 
    {
        EcsFilter<Unit, Attackable, CollisionComponent, IsAttackingComponent, TransformComponent> _filter;

        
        SceneData _sceneData;

        void IEcsRunSystem.Run () {
            foreach (var i in _filter)
            {
                ref var unit = ref _filter.Get1(i);
                ref var attackable = ref _filter.Get2(i);
                ref var collisionComponent = ref _filter.Get3(i);

                if (attackable.Target == null)
                    continue;

                if (unit.gameObject == collisionComponent.first && attackable.Target.gameObject == collisionComponent.other)
                {
                    ref var isAttacking = ref _filter.Get4(i);
                    ref var transform = ref _filter.Get5(i);
                    
                    isAttacking.IsAttacking = OnTargetCollision(transform.Transform, transform.Transform.localScale.x);
                }
            }
        }

        bool OnTargetCollision(Transform transform, float XScale)
        {
            return Physics.Raycast(
                transform.position,
                transform.TransformDirection(Vector3.forward),
                _sceneData.RayDistance * XScale,
                _sceneData.AttackableLayer);
        }
    }
}