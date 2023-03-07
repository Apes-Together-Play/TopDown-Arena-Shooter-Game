using DefaultNamespace;
using UnityEngine;

namespace WeaponManager.Bullet
{
    public class LinearBulletMovement : Bullet
    {
        [SerializeField] private float velocity;
        private Vector2 _direction;
        
        protected override void Move()
        {
            transform.position += (Vector3)(_direction * velocity) * Time.deltaTime;
        }

        public override void Initialize(Vector2 targetRelativePosition)
        {
            _direction = targetRelativePosition.normalized;
            
            var angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Wall"))
            {
                Destroy(gameObject);
                return;
            }
            
            if (other.TryGetComponent(out IMortal mortal))
            {
                mortal.TakeDamage();
                Destroy(gameObject);
            }
        }
    }
}