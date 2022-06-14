using UnityEngine;

namespace Client 
{
    struct Unit 
    {
        public Teams team;
        public Material material;

        public GameObject gameObject;

        public void OnDestroy()
        {
            Object.Destroy(gameObject);
        }
    }
}