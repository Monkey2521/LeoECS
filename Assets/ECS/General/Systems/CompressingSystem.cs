using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class CompressingSystem : IEcsRunSystem 
    {
        EcsFilter<ScaleComponent, IsCompressingComponent, IsGroundedComponent, Bounceable> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var scale = ref _filter.Get1(i);
                ref var compressing = ref _filter.Get2(i);
                ref var grounded = ref _filter.Get3(i);

                if (grounded.grounded)
                {
                    compressing.IsCompressing = true;
                }

                scale.scale -= new Vector3
                    (
                        0,
                        (compressing.Timer <= (float)compressing.CompressionTime * 0.5f ? 1 : -1) * compressing.DeltaScale * Time.fixedDeltaTime,
                        0f
                    );
                compressing.Timer += Time.fixedDeltaTime;

                if (compressing.Timer >= compressing.CompressionTime)
                {
                    compressing.IsCompressing = false;
                    compressing.Timer = 0;
                }
            }
        }
    }
}