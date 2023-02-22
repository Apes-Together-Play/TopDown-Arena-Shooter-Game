using UnityEngine;

namespace WeaponManager.Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Transform trnsGunTip;
        [SerializeField] protected Transform trnsGun;

        [SerializeField] protected float attackSpeed;
        private Vector2 _mousePos;

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