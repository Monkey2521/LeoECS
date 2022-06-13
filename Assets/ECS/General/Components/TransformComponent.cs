using UnityEngine;

namespace Client {
    struct TransformComponent {
        public Transform Transform;

        public Vector3 Position
        {
            get => Transform.position;
            set => Transform.position = value;
        }

        public Vector3 scale
        {
            get => Transform.localScale;
            set => Transform.localScale = value;
        }
        
    }
}