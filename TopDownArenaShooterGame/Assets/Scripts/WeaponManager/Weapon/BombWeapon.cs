using System;
using System.Collections;
using UnityEngine;
using WeaponManager.Bullet;
using Random = UnityEngine.Random;

namespace WeaponManager.Weapon
{
    public class BombWeapon : Weapon
    {
        
        [SerializeField] private ParabolicBulletMovement bullet; // bi bullet movement alicak
        [SerializeField] private float angle;
        private float _randomAngle;
        private Vector2 _bulletDirection;
        private Vector2 _mouseRelativePosition;
        [SerializeField] private Vector2 accuracy; 
        
        public override void Shoot()
        {
             _mouseRelativePosition = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            
             /*
             _randomAngle = Mathf.Atan2(_mouseRelativePosition.y, _mouseRelativePosition.x) +
                            (Random.Range(-angle / 2, angle / 2) * Mathf.Deg2Rad);

            _bulletDirection.x = Mathf.Cos(_randomAngle) * Math.Abs(_mouseRelativePosition.x);
            _bulletDirection.y = Mathf.Sin(_randomAngle) * Math.Abs(_mouseRelativePosition.y);
            
            */
             _mouseRelativePosition.x += Random.Range(-accuracy.x, accuracy.x);
             _mouseRelativePosition.y += Random.Range(-accuracy.y, accuracy.y);
             
            var instantiatedBullet = Instantiate(bullet, trnsGunTip.position, Quaternion.identity);
            instantiatedBullet.Initialize(_mouseRelativePosition);
        }

        // has to be in every weapon class
    }
}