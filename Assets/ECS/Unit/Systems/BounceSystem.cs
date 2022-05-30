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

        // можно выделить отдельную систему и компонент, который будет отвечать за эту проверку
        // например IsGround компонент в котором хранится булевый флаг IsGrounded, 
        // над которым уже работает система CheckIsGrounded и выставляет соответсвующий флаг
        // зачем - в теории это может быть не единственная система, которой нужно знать на земле ли объект, 
        // каждая будет кидать рейкаст - пизда фепесам
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