using Client;
using Leopotam.Ecs;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    public EcsEntity entity { get; set; }

    private void OnCollisionEnter(Collision collision)
    {
        if (entity != null)
        {
            ref var collisionComponent = ref entity.Get<CollisionComponent>();

            collisionComponent.first = gameObject;
            collisionComponent.other = collision.gameObject;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (entity != null)
        {
            ref var triggerComponent = ref entity.Get<TriggerComponent>();

            triggerComponent.first = gameObject;
            triggerComponent.other = other.gameObject;
        }
    }
}
