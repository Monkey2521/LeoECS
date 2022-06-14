using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class IsGroundedCheckSystem : IEcsRunSystem 
    {
        SceneData _sceneData;

        EcsFilter<IsGroundedComponent, TransformComponent> _filter;
        
        void IEcsRunSystem.Run () {
            foreach (var i in _filter)
            {
                ref var isGrounded = ref _filter.Get1(i);
                ref var transform = ref _filter.Get2(i);

                isGrounded.grounded = OnGround(transform.Position, transform.scale.y);
            }
        }

        bool OnGround(Vector3 position, float scale)
        {
            return Physics.Raycast(
                position,
                Vector3.down,
                _sceneData.RayDistance * scale,
                _sceneData.GroundLayer);
        }
    }
}