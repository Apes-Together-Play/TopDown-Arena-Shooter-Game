using Stats;
using UnityEngine;
using UnityEngine.Serialization;
using WeaponManager.Weapon.Base;

namespace WeaponManager.Weapon
{
    //TODO ismini degistir
    public class OneBulletBaseWeapon : BaseWeapon
    {
        [FormerlySerializedAs("bullet")] [SerializeField] private Bullet.Base.BaseBullet baseBullet;
        [SerializeField] private Vector2 accuracy; //TODO can be changed not working so well
        private Vector2 _mouseRelativePosition;

        public override void Shoot(AttackStatHelper helper)
        {
            _mouseRelativePosition =
                Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; // TODO expensive method

            _mouseRelativePosition.x += Random.Range(-accuracy.x, accuracy.x);
            _mouseRelativePosition.y += Random.Range(-accuracy.y, accuracy.y);

            var instantiatedBullet = Instantiate(baseBullet, trnsGunTip.position, Quaternion.identity);
            instantiatedBullet.SetHelper(helper);
            instantiatedBullet.Fire(_mouseRelativePosition);
        }
    }
}