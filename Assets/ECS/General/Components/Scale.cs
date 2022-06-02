using UnityEngine;

namespace Client 
{
    struct Scale 
    {
        Transform _transform;
        public Vector3 scale
        {
            get => _transform.localScale;
            set => _transform.localScale = value;
        }

        public bool SetTransform(Transform transform)
        {
            if (_transform == null)
            {
                _transform = transform;
                return true;
            }

            return false;
        }
    }
}