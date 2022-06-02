using UnityEngine;

namespace Client 
{
    struct Moveable 
    {
        public Transform transform { get; private set; }
        public Vector3 Position
        { 
            get => transform.position;
            set => transform.position = value; 
        }
        
        public int speed;

        public bool SetTransform(Transform transform)
        {
            if (this.transform == null)
            {
                this.transform = transform;
                return true;
            }

            return false;
        }
    }
}