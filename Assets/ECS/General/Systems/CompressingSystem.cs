using Leopotam.Ecs;

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

                scale.scale -= (compressing.FrameCount <= (int)(compressing.MaxFrame * 0.5f) ? 1 : -1) * 
                    UnityEngine.Vector3.one * compressing.DeltaScale;

                compressing.FrameCount++;

                if (compressing.FrameCount >= compressing.MaxFrame)
                {
                    compressing.IsCompressing = false;
                    compressing.FrameCount = 0;
                }
            }
        }
    }
}