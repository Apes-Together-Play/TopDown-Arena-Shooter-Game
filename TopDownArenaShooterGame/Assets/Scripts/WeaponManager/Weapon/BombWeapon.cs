using System;
using System.Collections;
using UnityEngine;
using WeaponManager.Bullet;
using Random = UnityEngine.Random;

namespace WeaponManager.Weapon
{
    //TODO ismini degistir
    public class BombWeapon : Weapon
    {
        
        [SerializeField] private Bullet.Bullet bullet;
        private Vector2 _mouseRelativePosition;
        
        [SerializeField] private Vector2 accuracy; //TODO can be changed not working so well
        
        
        public override void Shoot()
        {
             _mouseRelativePosition = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            
             _mouseRelativePosition.x += Random.Range(-accuracy.x, accuracy.x);
             _mouseRelativePosition.y += Random.Range(-accuracy.y, accuracy.y);
             
            var instantiatedBullet = Instantiate(bullet, trnsGunTip.position, Quaternion.identity);
            instantiatedBullet.Initialize(_mouseRelativePosition);
        }

        // has to be in every weapon class
    }
}