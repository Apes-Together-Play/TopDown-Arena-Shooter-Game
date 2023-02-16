using UnityEngine;

namespace Player
{
    public class Weapon : MonoBehaviour
    {
        
        [SerializeField] private GameObject bullet;
        [SerializeField] private Transform trnsGunTip;
      
        
        [SerializeField] private Vector2 groundDispenseVelocity;
        [SerializeField] private Vector2 verticalDispenseVelocity;
        
        
        // has to be an abstract class 
        public void Shoot()
        {
            if (Input.GetMouseButtonDown(0)){ // add IE .... tarzi bir condition daha ekle
                GameObject insantiatedBullet = Instantiate(bullet, trnsGunTip.position, Quaternion.identity);
                insantiatedBullet.GetComponent<BombMovement>().Initialize(trnsGun.right * Random.Range(groundDispenseVelocity.x, groundDispenseVelocity.y), Random.Range(verticalDispenseVelocity.x, verticalDispenseVelocity.y));
            }
        }
        

        // has to be in every weapon class
        private Vector2 mousePos;
        
        [SerializeField] private Transform trnsGun;
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