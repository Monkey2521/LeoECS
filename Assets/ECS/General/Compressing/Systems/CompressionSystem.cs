using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    sealed class CompressionSystem : IEcsRunSystem
    {
        EcsFilter<IsCompressingComponent, TransformComponent> _filter;

        UnitStatsData _data;
        
        void IEcsRunSystem.Run ()
        {
            foreach (var i in _filter)
            {
                ref var compression = ref _filter.Get1(i);

                if (compression.IsCompressing)
                {
                    if (compression.Timer >= _data.CompressionTime)
                    {
                        compression.Timer = 0;
                        compression.IsCompressing = false;
                    }

                    ref var transform = ref _filter.Get2(i);

                    float deltaXZ = _data.CompressionDeltaScale * Time.fixedDeltaTime;
                    float deltaY = deltaXZ * 2;
                    int timeMultiplier = (compression.Timer >= _data.CompressionTime * 0.5f ? 1 : -1);

                    transform.scale += new Vector3
                        (
                            deltaXZ * (-timeMultiplier),
                            deltaY * timeMultiplier,
                            deltaXZ * (-timeMultiplier)
                        );

                    compression.Timer += Time.fixedDeltaTime;
                }
            }
        }
    }
}