using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class BounceSystem : IEcsRunSystem {

        EcsFilter<Bounce> _filter;
        SceneData _sceneData;

        void IEcsRunSystem.Run () {
            foreach (var i in _filter)
            {
                ref var bounce = ref _filter.Get1(i);
                if (OnGround(bounce.rigidbody))
                    bounce.rigidbody.AddForce(new Vector3(0, bounce.force, 0) * Time.fixedDeltaTime, ForceMode.Impulse);
            }
        }

        bool OnGround(Rigidbody rigidbody)
        {
            return Physics.Raycast(
                rigidbody.transform.position,
                Vector3.down,
                _sceneData.RayDistance * rigidbody.transform.localScale.x,
                _sceneData.Layer);
        }
    }
}