using Client;
using Leopotam.Ecs;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    public EcsWorld ecsWorld { get; set; }

    private void OnCollisionEnter(Collision collision)
    {
        var hit = ecsWorld.NewEntity();

        ref var collisionComponent = ref hit.Get<CollisionComponent>();

        collisionComponent.first = transform.root.gameObject;
        collisionComponent.other = collision.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        var hit = ecsWorld.NewEntity();

        ref var triggerComponent = ref hit.Get<TriggerComponent>();

        triggerComponent.first = transform.root.gameObject;
        triggerComponent.other = other.gameObject;
    }
}
