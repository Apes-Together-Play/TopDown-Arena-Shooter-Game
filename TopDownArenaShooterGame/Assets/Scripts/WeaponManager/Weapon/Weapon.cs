using Stats;
using UnityEngine;

namespace WeaponManager.Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected Transform trnsGunTip;
        [SerializeField] protected Transform trnsGun;
        [SerializeField] protected float attackSpeed;
        [SerializeField] private SpriteRenderer sprRndGun;

        private Vector2 _mousePos;
        public float AttackSpeed => attackSpeed;

        public abstract void Shoot(AttackStatHelper helper); // change it into a

        public void RotateGun()
        {
            _mousePos = Input.mousePosition;
            var objectPos = Camera.main.WorldToScreenPoint(trnsGun.position);
            _mousePos.x -= objectPos.x;
            _mousePos.y -= objectPos.y;

            var angle = Mathf.Atan2(_mousePos.y, _mousePos.x) * Mathf.Rad2Deg;
            trnsGun.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        public void Flip()
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            sprRndGun.flipY = !(mouseWorldPos.x > transform.position.x);
        }
    }
}