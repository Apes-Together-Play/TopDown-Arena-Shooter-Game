using UnityEngine;

namespace WeaponManager.Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        
        [SerializeField] public Transform trnsGunTip;
        [SerializeField] public Transform trnsGun;
        private Vector2 _mousePos;
        
        
        [SerializeField] protected float attackSpeed;
        

        
        
        public abstract void Shoot();
        
        public float GetAttackSpeed()
        {
            return attackSpeed;
        }
        
        
        public void RotateGun()
        {
            _mousePos = Input.mousePosition;
            Vector3 objectPos = Camera.main.WorldToScreenPoint(trnsGun.position);
            _mousePos.x -= objectPos.x;
            _mousePos.y -= objectPos.y;

            float angle = Mathf.Atan2(_mousePos.y, _mousePos.x) * Mathf.Rad2Deg;
            trnsGun.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        
    }
}