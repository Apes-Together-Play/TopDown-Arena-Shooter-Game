using OldStats;
using UnityEngine;

namespace WeaponManager.Bullet.Base
{
    public abstract class BaseBullet : MonoBehaviour, IDamageGiver
    {
        [Header("Objects")] [SerializeField] protected Transform trnsObject;

        [SerializeField] protected Transform trnsBody;

        public AttackStatHelper Helper;
        
        public abstract void Fire(Vector2 targetRelativePosition);

        public void SetHelper(AttackStatHelper helper)
        {
            Helper = helper;
        }

        public void GiveDamage(IDamageTaker taker)
        {
            taker.TakeDamage(this);
        }
    }
}