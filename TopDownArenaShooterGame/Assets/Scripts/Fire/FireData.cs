using UnityEngine;

namespace Fire
{
    public struct FireData
    {
        public Vector2 Direction;
        public float Damage;
        public float LifeSteal;
        public float Knockback;

        
        public FireData(Vector2 direction, float damage, float lifeSteal, float knockback)
        {
            Direction = direction;
            Damage = damage;
            LifeSteal = lifeSteal;
            Knockback = knockback;
        }
    }
}