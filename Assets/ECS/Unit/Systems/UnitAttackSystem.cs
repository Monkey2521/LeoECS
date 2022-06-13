using Leopotam.Ecs;

namespace Client 
{
    sealed class UnitAttackSystem : IEcsRunSystem 
    {
        EcsFilter<Unit, Attackable, HealthComponent> _filter;

        void IEcsRunSystem.Run ()
        {
            foreach(var i in _filter)
            {

            }    
        }

        bool IsAttacking()
        {
            return false;
        }
    }
}