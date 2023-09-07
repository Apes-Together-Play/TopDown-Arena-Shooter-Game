using Stats;
using UnityEngine;

namespace WeaponManager.Bullet.Base
{
    public abstract class BaseBullet : MonoBehaviour
    {
        [Header("Objects")] [SerializeField] protected Transform trnsObject;

        [SerializeField] protected Transform trnsBody;

        public AttackStatHelper Helper;
        
        public abstract void Fire(Vector2 targetRelativePosition);

        public void SetHelper(AttackStatHelper helper)
        {
            Helper = helper;
        }
    }
}