using UnityEngine;

namespace WeaponManager.Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        
        [SerializeField] protected Transform trnsGunTip;
        [SerializeField] protected Transform trnsGun;
        [SerializeField] protected float attackSpeed;
        [SerializeField] private SpriteRenderer sprRndGun;

        protected Camera MainCamera;
        private void Awake()
        {
            Debug.Log("AA");
            MainCamera = FindObjectOfType<Camera>();
            Debug.Log(MainCamera);
        }

        private Vector2 mousePos;
        public float AttackSpeed => attackSpeed;
        public abstract void Shoot();
        
        public void RotateGun()
        {
            mousePos = Input.mousePosition;
            var objectPos = Camera.main.WorldToScreenPoint(trnsGun.position);
            mousePos.x -= objectPos.x;
            mousePos.y -= objectPos.y;

            var angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            trnsGun.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        
        public void Flip()
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            sprRndGun.flipY = !(mouseWorldPos.x > transform.position.x);
        }
    }
}