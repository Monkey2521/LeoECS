using UnityEngine;

namespace Client 
{
    struct Attackable {
        public Transform Target;
        public int Damage;
        public float AttackTime;
        public float Timer;
    }
}