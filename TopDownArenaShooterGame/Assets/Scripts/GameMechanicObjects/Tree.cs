using UnityEngine;
using WeaponManager.Bullet.Base;

namespace GameMechanicObjects
{
    public class Tree : MonoBehaviour, IBulletHandler, IDamageTaker
    {
        public void HandleBullet(BulletData bullet)
        {
            Debug.Log(bullet.Speed);
        }

        public void TakeDamage(IDamageGiver giver)
        {
            giver.GiveDamage(this);
        }
    }
}