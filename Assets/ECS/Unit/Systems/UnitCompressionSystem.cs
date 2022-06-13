using Leopotam.Ecs;

namespace Client 
{
    sealed class UnitCompressionSystem : IEcsRunSystem 
    {
        EcsFilter<CompressionCheckerComponent, IsCompressingComponent, IsGroundedComponent> _filter;
        
        void IEcsRunSystem.Run () 
        {
            foreach(var i in _filter)
            {
                ref var checker = ref _filter.Get1(i);
                ref var isGrounded = ref _filter.Get3(i);

                checker.PreviousGrounded = checker.CurrentGrounded;
                checker.CurrentGrounded = isGrounded.grounded;

                if (checker.CurrentGrounded && !checker.PreviousGrounded)
                {
                    ref var isCompressing = ref _filter.Get2(i);
                    isCompressing.IsCompressing = true;
                }
            }
        }
    }
}