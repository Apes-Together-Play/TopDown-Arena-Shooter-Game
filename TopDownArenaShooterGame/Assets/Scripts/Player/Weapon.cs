using System.Collections;
using UnityEngine;

namespace Player
{
    public class Weapon : MonoBehaviour
    {
        
        [SerializeField] private BombMovement bullet; // bi bullet movement alicak
        
        [SerializeField] private Transform trnsGunTip;
        [SerializeField] private Transform trnsGun;
        
        [SerializeField] private float attackSpeed;
        private Vector2 mousePos;

        public float GetAttackSpeed()
        {
            return attackSpeed;
        }
        
        
        // has to be an abstract class 
        public void Shoot()
        {
            Vector2 mouseRelativePosition = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);

            var instantiatedBullet = Instantiate(bullet, trnsGunTip.position, Quaternion.identity);
            instantiatedBullet.Initialize(mouseRelativePosition);
        }
        

        // has to be in every weapon class

        public void RotateGun()
        {
            mousePos = Input.mousePosition;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(trnsGun.position);
            mousePos.x -= objectPos.x;
            mousePos.y -= objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            trnsGun.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}