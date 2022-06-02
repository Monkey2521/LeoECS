using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class IsGroundedCheckSystem : IEcsRunSystem 
    {
        SceneData _sceneData;

        EcsFilter<IsGrounded> _filter;
        
        void IEcsRunSystem.Run () {
            foreach (var i in _filter)
            {
                ref var isGrounded = ref _filter.Get1(i);

                isGrounded.grounded = OnGround(isGrounded.Position, isGrounded.XScale);
            }
        }

        bool OnGround(Vector3 position, float scale)
        {
            return Physics.Raycast(
                position,
                Vector3.down,
                _sceneData.RayDistance * scale,
                _sceneData.Layer);
        }
    }
}