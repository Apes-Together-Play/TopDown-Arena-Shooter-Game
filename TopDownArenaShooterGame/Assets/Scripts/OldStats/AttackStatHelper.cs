namespace OldStats
{
    public struct AttackStatHelper
    {
        public float Knockback;
        public float LifeSteal;
        public float Damage;
        
        public AttackStatHelper(float knockback, float lifeSteal, float damage)
        {
            Knockback = knockback;
            LifeSteal = lifeSteal;
            Damage = damage;
        }
    }
}