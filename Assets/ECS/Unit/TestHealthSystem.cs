using Leopotam.Ecs;

namespace Client {
    sealed class TestHealthSystem : IEcsRunSystem 
    {
        EcsFilter<Unit, HealthComponent, TransformComponent> _filter;

        int _frameCount = 0;
        void IEcsRunSystem.Run () 
        {
            foreach(var i in _filter)
            {
                if (_frameCount >= 9)
                {
                    ref var health = ref _filter.Get2(i);

                    health.HP++;

                    _frameCount = 0;
                }

                _frameCount++;
            }
        }
    }
}