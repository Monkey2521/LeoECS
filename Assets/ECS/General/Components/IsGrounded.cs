using UnityEngine;

namespace Client 
{
    struct IsGrounded 
    {
        Transform _transform;

        public Vector3 Position => _transform.position;
        public float XScale => _transform.localScale.x;
        public bool grounded;

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