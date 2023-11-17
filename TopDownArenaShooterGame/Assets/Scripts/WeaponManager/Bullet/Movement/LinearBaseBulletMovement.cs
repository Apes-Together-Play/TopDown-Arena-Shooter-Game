using GameMechanicObjects;
using Interfaces;
using UnityEngine;
using WeaponManager.Bullet.Base;

namespace WeaponManager.Bullet.Movement
{
    public class LinearBaseBulletMovement : Base.BaseBullet
    {
        [SerializeField] private float velocity;
        private Vector2 _direction;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var bulletData = new BulletData() {Speed = 10f};
            if(other.TryGetComponent(out IBulletHandler handler))
            {
                handler.HandleBullet(bulletData);
            }
        }

        private void Update()
        {
            transform.position += (Vector3)(_direction * velocity) * Time.deltaTime;
        }
        
        public override void Fire(Vector2 targetRelativePosition)
        {
            _direction = targetRelativePosition.normalized;

            var angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}