using Leopotam.Ecs;
using UnityEngine;

namespace Client 
{
    sealed class BounceSystem : IEcsRunSystem 
    {
        EcsFilter<Bounceable, IsGroundedComponent> _filter;

        void IEcsRunSystem.Run()
        {
            foreach (var i in _filter)
            {
                ref var bounce = ref _filter.Get1(i);
                ref var isGrounded = ref _filter.Get2(i);
                //ref var compressing = ref _filter.Get3(i);

                if (isGrounded.grounded)
                    bounce.rigidbody.AddForce(new Vector3(0, bounce.force, 0) * Time.fixedDeltaTime, ForceMode.Impulse);
            }
        }
    }
}