using Leopotam.Ecs;

namespace Client
{
    sealed class HitSystem : IEcsRunSystem
    {

        readonly EcsWorld _world = null;
        private EcsFilter<HitComponent> hits;

        void IEcsRunSystem.Run()
        {
            foreach (var i in hits)
            {
                ref var hitComponent = ref hits.Get1(i);

                ref var healthComponent = ref hits.GetEntity(i).Get<Health>();
                ref var unitComponent = ref hits.GetEntity(i).Get<Unit>();

                if(hitComponent.f)
            }
        }
    }
}